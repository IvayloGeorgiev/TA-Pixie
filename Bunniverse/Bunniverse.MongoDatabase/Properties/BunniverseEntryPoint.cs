namespace Bunniverse.MongoDatabase
{
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using MongoDB.Driver.GridFS;
    using MongoDB.Driver.Linq;
    using System;
    using MongoDatabase.Contracts;
    class BunniverseEntryPoint
    {
        static void Main(string[] args)
        {
            var connectionString = "mongodb://viktor:qwerty@ds063879.mongolab.com:63879/bunniverse";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("bunniverse");
            var bunnies = database.GetCollection<Bunny>("bunnies");
            IDBFactory DBFactory = new DBFactory();

            //DBFactory.CreateBunnies();

            foreach (var bunny in bunnies.FindAll())
            {
                Console.WriteLine(bunny.Name);
            }

            //DBFactory.CreateShips();

            var ships = database.GetCollection<Ship>("ships");

            foreach (var ship in ships.FindAll())
            {
                Console.Write(ship.Name + "--> ");
                foreach (var bunny in ship.Bunnies)
                {
                    Console.Write(bunny.Name + " ");
                }
                Console.WriteLine("\n");
            }

            //DBFactory.CreatePlanets();

            var planets = database.GetCollection<Planet>("planets");
            foreach (var planet in planets.FindAll())
            {
                Console.Write(planet.Name + "--> ");
                foreach (var ship in planet.Ships)
                {
                    Console.Write(ship.Name + " ");
                }
                Console.WriteLine("\n");
            }

            //DBFactory.CreateFood();

            var foods = database.GetCollection<Food>("food");

            //DBFactory.CreateCargos();

            var cargos = database.GetCollection<Cargo>("cargos");

            foreach (var cargo in cargos.FindAll())
            {
                Console.WriteLine(cargo.Ship.Name + " --> " + cargo.Food.Name + " : " + cargo.FoodQuantity + "\n");
            }

        }
    }
}
