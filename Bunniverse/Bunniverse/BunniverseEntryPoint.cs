namespace Bunniverse
{
    using System.Collections.Generic;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using MongoDB.Driver.GridFS;
    using MongoDB.Driver.Linq;
    using System;
    using System.Linq;
    using System.Web;
    using Newtonsoft.Json;
    using System.IO;
    using System.Runtime.Serialization.Json;

    class BunniverseEntryPoint
    {
        static void Main(string[] args)
        {                        
            /*
            var bunnyVerse = new BunnyverseEntities();
            var planets = bunnyVerse.Planets.AsQueryable();
            var ships = bunnyVerse.Ships.AsQueryable();
            var visits = bunnyVerse.Visits.AsQueryable();
            var anonShips = new List<object>();
            foreach (var ship in ships)
            {
                Console.WriteLine(ship.ShipName);
            }
            anonShips.Add(new { ShipId = 1, PlanetsVisited = 42, DistanceTravelled = 3.14 });
            anonShips.Add(new { ShipId = 2, PlanetsVisited = 9001, DistanceTravelled = 1337.1337 });
            ShipJSONConverter.GenerateReports(ships);*/
        }
    }
}
