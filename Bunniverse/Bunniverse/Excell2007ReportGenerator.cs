using MySql.Data.MySqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Linq;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using Bunniverse.Data;

namespace Bunniverse
{
    public class Excell2007ReportGenerator
    {
        public static void GenerateExcell2007Report()
        {
            SQLiteConnection mDbConnection = new SQLiteConnection(@"Data Source=..\..\..\..\SQLite_BunniverseDB\BunniverseDB.db;Version=3;");
            mDbConnection.Open();

            string sqlCommand = "select * from Ships";
            SQLiteCommand command = new SQLiteCommand(sqlCommand, mDbConnection);

            SQLiteDataAdapter sqLiteAdapter = new SQLiteDataAdapter(sqlCommand, mDbConnection);
            DataTable sqLiteDataTable = new DataTable();
            sqLiteAdapter.Fill(sqLiteDataTable);

            //MySqlConnection mySqlConnection = new MySqlConnection("SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD=kR@asin88;");
            //string MySQLquery = "select * from reports";

            //MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(MySQLquery, mySqlConnection);
            //DataTable mySqlDataTable = new DataTable();
            //mySqlAdapter.Fill(mySqlDataTable);
                                   
            Console.WriteLine("Creating report from SQLite and MySQL");

            FileInfo newFile = new FileInfo( @"..\..\..\reportFromSQLite.xlsx");
            if (newFile.Exists)
            {
                newFile.Delete();  // ensures we create a new workbook
                newFile = new FileInfo(@"..\..\..\reportFromSQLite.xlsx");
            }

            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Ships");

                worksheet.Cells[1, 1].Value = "ShipName";
                worksheet.Cells[1, 2].Value = "Fuel Per 100du";
               // worksheet.Cells[1, 3].Value = "ShipID in MySQL";
              //  worksheet.Cells[1, 4].Value = "ShipName in MySQL";
                worksheet.Cells[1, 3].Value = "Total Distance Traveled";
                worksheet.Cells[1, 4].Value = "Planets Visited";
                worksheet.Cells[1, 5].Value = "Total Fuel Used";
                worksheet.Cells["E2:E6"].Formula = "B2*C2/100";

                using (var range = worksheet.Cells[1, 1, 1, 5])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.CadetBlue);
                    range.Style.Font.Color.SetColor(Color.Black);
                }

                using (var ctx = new MySqlEntities())
                {
                    var ships = ctx.ShipsTravel.ToList();

                    for (int i = 0; i < 5; i++)
                    {
                        var ship = new ShipsTravel
                        {
                            ID = i + 1,
                            PlanetsVisited = 5 + i,
                            ShipName = "Ship" + i,
                            TotalDistance = 23 * (i+1)
                        };
                        ships.Add(ship);
                    }
                    ctx.SaveChanges();
                    
                    for (int i = 1; i <= sqLiteDataTable.Rows.Count; i++)
                    {
                        for (int j = 1; j <= sqLiteDataTable.Columns.Count; j++)
                        {
                            var data = sqLiteDataTable.Rows[i - 1].ItemArray[j - 1];
                            Console.WriteLine(data);
                            worksheet.Cells[i + 1, j].Value = data;
                        }
                    }

                    for (int i = 0; i < ships.Count; i++)
                    {
                       // var shipID = ships[i].ID;
                      //  var shipName = ships[i].ShipName;
                        var distanceTravled = ships[i].TotalDistance;
                        var planetsVisited = ships[i].PlanetsVisited;

                      //  worksheet.Cells[i + 2, 3].Value = shipID;
                     //   worksheet.Cells[i + 2, 4].Value = shipName;
                        worksheet.Cells[i + 2, 3].Value = distanceTravled;
                        worksheet.Cells[i + 2, 4].Value = planetsVisited;
                        
                    }
                }
                package.Save();
            }
        }
    }
}
