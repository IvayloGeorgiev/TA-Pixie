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
           // MySqlDatabase.MySqlCreator.CreateDatabase();
           // Excell2007ReportGenerator.GenerateExcell2007Report();

            //var dbFactory = new BunniverseFactory();
            //dbFactory.GenerateMongoData();

            //IMongoDBToSQLConverter sqlConverter = new MongoDBToSQLConverter();
            //sqlConverter.ConvertMongoToSQL();

            var zipReader = new ExcelZipReader("..\\..\\..\\Files\\MealsData.zip", "..\\..\\..\\Files\\Temp");
            zipReader.ReadExcels();
           
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
          AstrogationPDFReport.GenerateReports();
          XMLReport.GenerateReports();
          //JsonReporter jsonReport = new JsonReporter("..\\..\\..\\");
        }
    }
}