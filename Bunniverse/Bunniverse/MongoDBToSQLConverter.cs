using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunniverse.Contracts;
using MongoDB.Driver;
using Bunniverse.MongoDatabase;
using Bunniverse.Data;
using Bunniverse.Models;

namespace Bunniverse
{
    class MongoDBToSQLConverter : IMongoDBToSQLConverter
    {
        private const string connectionString = "mongodb://viktor:qwerty@ds063879.mongolab.com:63879/bunniverse";
        public void ConvertMongoToSQL()
        {
            //var connectionString = "mongodb://viktor:qwerty@ds063879.mongolab.com:63879/bunniverse";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("bunniverse");

            var planets = database.GetCollection<Planet>("planets");
            var ships = database.GetCollection<Ship>("ships");
            var foods = database.GetCollection<Food>("foods");
            var cargos = database.GetCollection<Cargo>("cargos");
            var bunnies = database.GetCollection<Bunny>("bunnies");
            IDBFactory DBFactory = new DBFactory();

            foreach (var bunny in bunnies.FindAll())
            {
                Console.WriteLine("Bunny " + bunny.BunnyName + " in ship " + bunny.Ship.ShipName + " at planet " + bunny.Ship.Planet.PlanetName);
            }

              using (var bunniverseSQL = new BunniverseEntities())
              {
                  //foreach (var planet in planets.FindAll())
                  //{
                  //    Console.WriteLine("planet " + planet.PlanetName);
                  //    Console.Write(planet.PlanetId+" " + planet.X);
                  //}

                  foreach (var planet in planets.FindAll())
                  {
                      bunniverseSQL.Planets.Add(new Planet() { PlanetName = planet.PlanetName, X = planet.X, Y = planet.Y, Z = planet.Z });
                      //bunniverseSQL.Planets.Add(planet);
                  }
                  bunniverseSQL.SaveChanges();
                  foreach (var ship in ships.FindAll())
                  {
                      //bunniverseSQL.Ships.Add(ship);
                      bunniverseSQL.Ships.Add(new Ship(){ShipName = ship.ShipName, EnginePower = ship.EnginePower, PlanetId = ship.PlanetId});
                  }
                  bunniverseSQL.SaveChanges();
                  foreach (var food in foods.FindAll())
                  {
                      bunniverseSQL.Foods.Add(new Food() { FoodName = food.FoodName});
                      //bunniverseSQL.Foods.Add(food);
                  }
                  bunniverseSQL.SaveChanges();
                  foreach (var bunny in bunnies.FindAll())
                  {
                      bunniverseSQL.Bunnies.Add(new Bunny() { BunnyName = bunny.BunnyName, ShipId = bunny.ShipId});
                      //bunniverseSQL.Bunnies.Add(bunny);
                  }
                  bunniverseSQL.SaveChanges();
                  foreach (var cargo in cargos.FindAll())
                  {
                      bunniverseSQL.Cargoes.Add(new Cargo() { FoodId = cargo.FoodId, ShipId = cargo.ShipId, FoodQuantity = cargo.FoodQuantity});
                      //bunniverseSQL.Cargoes.Add(cargo);
                  }
                  bunniverseSQL.SaveChanges();
              }

        }
    }
}
