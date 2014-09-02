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
    using Bunniverse.Models;
    using MongoDB.Bson.Serialization;
    using Bunniverse.Contracts;
    using Bunniverse.MongoDatabase;

    class BunniverseEntryPoint
    {
        static void Main(string[] args)
        {
           // BsonClassMap.RegisterClassMap<Bunny>();
            var dbFactory = new BunniverseFactory();
            dbFactory.GenerateMongoData();
           var connectionString = "mongodb://viktor:qwerty@ds063879.mongolab.com:63879/bunniverse";
           var client = new MongoClient(connectionString);
           var server = client.GetServer();
           var database = server.GetDatabase("bunniverse");

           var bunnies = database.GetCollection<Bunny>("bunnies");

           for (int i = 0; i < 45; i++)
           {
               string bunnyName = String.Format("IvoBunny" + i);
               var bunny = new Bunny { BunnyName = bunnyName };
               bunnies.Insert(bunny);
           }

           foreach (var item in bunnies.FindAll())
           {
               Console.WriteLine(item.BunnyID);
           }
           // var bunnyVerse = new BunnyverseEntities();
          // var planets = bunnyVerse.Planets.AsQueryable();
          // var ships = bunnyVerse.Ships.AsQueryable();
          // var visits = bunnyVerse.Visits.AsQueryable();
          // var anonShips = new List<object>();
          // foreach (var ship in ships)
          // {
          //     Console.WriteLine(ship.ShipName);
          // }
          // anonShips.Add(new { ShipId = 1, PlanetsVisited = 42, DistanceTravelled = 3.14 });
          // anonShips.Add(new { ShipId = 2, PlanetsVisited = 9001, DistanceTravelled = 1337.1337 });
          //// ShipJSONConverter.GenerateReports(ships);
          ////AstrogationPDFReport.GenerateReports();
        }
    }
}