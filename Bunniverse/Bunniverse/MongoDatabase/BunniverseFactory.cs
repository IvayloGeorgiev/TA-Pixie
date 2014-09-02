namespace Bunniverse.MongoDatabase
{
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using MongoDB.Driver.GridFS;
    using MongoDB.Driver.Linq;
    using System;
    using Bunniverse.Contracts;
    using Bunniverse.Models;
    using Bunniverse.MongoDatabase;
    class BunniverseFactory
    {
        public void GenerateMongoData()
        {
            var connectionString = "mongodb://viktor:qwerty@ds063879.mongolab.com:63879/bunniverse";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();         
            var database = server.GetDatabase("bunniverse");

            database.DropCollection("bunnies");
            database.DropCollection("ships");
            database.DropCollection("planets");
            database.DropCollection("foods");
            database.DropCollection("cargos");

            var bunnies = database.GetCollection<Bunny>("bunnies");
            IDBFactory DBFactory = new DBFactory();

            DBFactory.CreateBunnies();

            foreach (var bunny in bunnies.FindAll())
            {
                Console.WriteLine(bunny.BunnyName);
            }

            DBFactory.CreateShips();

            var ships = database.GetCollection<Ship>("ships");

            foreach (var ship in ships.FindAll())
            {
                Console.Write(ship.ShipName + "--> ");
                foreach (var bunny in ship.Bunnies)
                {
                    Console.Write(bunny.BunnyName + " ");
                }
                Console.WriteLine("\n");
            }

            DBFactory.CreatePlanets();
          
            var planets = database.GetCollection<Planet>("planets");
            foreach (var planet in planets.FindAll())
            {
                Console.Write(planet.PlanetName + "--> ");
                foreach (var ship in planet.Ships)
                {
                    Console.Write(ship.ShipName + " ");
                }
                Console.WriteLine("\n");
            }

            DBFactory.CreateFood();

            var foods = database.GetCollection<Food>("foods");

            DBFactory.CreateCargos();

            var cargos = database.GetCollection<Cargo>("cargos");

            foreach (var cargo in cargos.FindAll())
            {
                Console.WriteLine(cargo.Ship.ShipName + " --> " + cargo.Food.FoodName + " : " + cargo.FoodQuantity + "\n");
            }

        }
    }
}
