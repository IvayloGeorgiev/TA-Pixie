namespace Bunniverse
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using Bunniverse.Contracts;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Creates a new ShipJSONConverer for generating JSON reports by passed data objects
    /// </summary>
    [DataContract]
    public class ShipJSONConverter : ISQLJSONConverter
    {
        [DataMember]
        string ShipId;
        [DataMember]
        string PlanetsVisited;
        [DataMember]
        string DistanceTravelled;

        /// <summary>
        /// Initializes a new instance of ShipJSONConverer for making JSON reports
        /// </summary>
        /// <param name="dataObject">Data object which must have the properties ShipId, PlanetsVisited and DistanceTravelled</param>
        public ShipJSONConverter(object dataObject)
        {
            Type myType = dataObject.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                string propName = prop.Name;
                object propValue = prop.GetValue(dataObject);
                switch (propName)
                {
                    case "ShipId":
                        this.ShipId = propValue.ToString();
                        break;
                    case "PlanetsVisited":
                        this.PlanetsVisited = propValue.ToString();
                        break;
                    case "DistanceTravelled":
                        this.DistanceTravelled = propValue.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        public string ConvertToJSON()
        {
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(this.GetType());
            ser.WriteObject(stream, this);

            stream.Position = 0;
            using (StreamReader sr = new StreamReader(stream))
            {
                return sr.ReadToEnd();
            }
        }

        public void SaveJSONToFile(string json, string fn)
        {
            string formattedJSON = json
                    .Replace("{", "{\n\t")
                    .Replace(":", " : ")
                    .Replace("\",", "\",\n\t")
                    .Replace("}", "\n}");

            using (StreamWriter sw = new StreamWriter(fn))
            {
                sw.Write(formattedJSON);
            }
        }

        private static IEnumerable<ShipJSONConverter> GenerateReportData(IEnumerable<Ship> ships)
        {
            // TODO: The code hasn't been run. May have errors. Should check if ship.Visits are sorted by VisitID
            var reportData = new List<object>();
            foreach (var ship in ships)
            {
                double? distanceTravelled = null;
                int planetsVisited = 0;
                Planet lastVisited = new Planet();
                foreach (var visit in ship.Visits)
                {
                    if (distanceTravelled == null)
                    {
                        distanceTravelled = 0;
                    }
                    else
                    {
                        double distanceX = Math.Abs(visit.Planet.X - lastVisited.X);
                        double distanceY = Math.Abs(visit.Planet.Y - lastVisited.Y);
                        double distanceZ = Math.Abs(visit.Planet.Z - lastVisited.Z);
                        double distanceIn2D = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
                        distanceTravelled += Math.Sqrt(distanceIn2D * distanceIn2D + distanceZ * distanceZ);
                    }

                    planetsVisited++;
                    lastVisited = visit.Planet;
                }

                reportData.Add(new { 
                    ShipId = ship.ShipID, 
                    PlanetsVisited = planetsVisited, 
                    DistanceTravelled = distanceTravelled 
                });
            }

            return reportData.Select(ship => new ShipJSONConverter(ship));
        }

        private static MySqlConnection ConnectToDb()
        {
            string connStr = @"server=localhost;userid=root;";
            var dbConnection = new MySqlConnection(connStr);
            dbConnection.Open();

            return dbConnection;
        }

        private static void GenerateMySqlReport(MySqlConnection dbConnection, IEnumerable<ShipJSONConverter> ships)
        {
            string scriptFN = @"../../Database-Scripts/createDatabaseAndReportTable.sql";
            var script = new MySqlScript(dbConnection, File.ReadAllText(scriptFN));
            script.Execute();

            StringBuilder queryBuilder = new StringBuilder("INSERT INTO shipsreport VALUES ");
            for (int i = 0, len = ships.Count(); i < len; i++)
            {
                queryBuilder.AppendFormat("(@ShipId{0},@PlanetsVisited{0},@DistanceTravelled{0}),", i);
            }
            queryBuilder.Replace(',', ';', queryBuilder.Length - 1, 1);

            MySqlCommand command = new MySqlCommand(queryBuilder.ToString(), dbConnection);
            int j = 0;
            foreach (var ship in ships)
            {
                command.Parameters.AddWithValue("@ShipId" + j, ship.ShipId);
                command.Parameters.AddWithValue("@PlanetsVisited" + j, ship.PlanetsVisited);
                command.Parameters.AddWithValue("@DistanceTravelled" + j, ship.DistanceTravelled);
                j++;
            }

            command.ExecuteNonQuery();
        }

        private static void SaveMySqlReport(IEnumerable<ShipJSONConverter> ships)
        {
            var dbConnection = ConnectToDb();
            GenerateMySqlReport(dbConnection, ships);
            dbConnection.Close();
        }

        /// <summary>
        /// Generates and saves reports to multitude of JSON files as well as the MySQL database
        /// </summary>
        /// <param name="ships">List of data objects which must have the properties ShipId, PlanetsVisited and DistanceTravelled</param>
        public static void GenerateReports(IEnumerable<Ship> ships)
        {
            var shipReportObjects = GenerateReportData(ships);

            SaveMySqlReport(shipReportObjects);

            foreach (var obj in shipReportObjects)
            {
                string json = obj.ConvertToJSON();
                obj.SaveJSONToFile(json, "../../JSON-Reports/" + obj.ShipId + ".json");
            }
        }
    }
}
