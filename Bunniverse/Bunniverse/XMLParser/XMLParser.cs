using Bunniverse.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Bunniverse.Models;
using MongoDB.Driver;
using Bunniverse.Data;

namespace Bunniverse
{
    public class XMLParser : IXMLParser
    {
        private const string connectionString = "mongodb://viktor:qwerty@ds063879.mongolab.com:63879/bunniverse";

        public void ParseXML()
        {
            var xml = XDocument.Load("../../../Files/visits-data.xml");

            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("bunniverse");
            var planets = database.GetCollection<Planet>("planets");
            var ships = database.GetCollection<Ship>("ships");
            database.DropCollection("visits");

            var visits = database.GetCollection<Visit>("visits");

            var allVisits = xml.Root.Descendants("visit").Select(c => c);
            int idCounter = 1;

            foreach (var currentVisit in allVisits)
            {
                string planetName = currentVisit.Attribute("planet-name").Value;
                DateTime date = DateTime.Parse(currentVisit.Attribute("date").Value);

                string shipName = currentVisit.Attribute("ship-name").Value;

                foreach (var foodGathered in currentVisit.Descendants())
                {
                    string foodName = foodGathered.Value;
                    int foodQuantity = int.Parse(foodGathered.Attribute("quantity").Value);
                }

                var planet = planets.FindAll().FirstOrDefault(p => p.PlanetName == planetName);
                var ship = ships.FindAll().FirstOrDefault(s => s.ShipName == shipName);

                Visit visit = new Visit()
                {
                    Planet = planet,
                    PlanetId = planet.PlanetId,
                    Ship = ship,
                    ShipId = ship.ShipId,
                    VisitId = idCounter,
                    Date = date
                };

                visits.Insert(visit);
                using (var bunniverseSQL = new BunniverseEntities())
                {
                    bunniverseSQL.Visits.Add(visit);
                    bunniverseSQL.SaveChanges();
                }

                idCounter++;
            }
        }
    }
}
