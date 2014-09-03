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
        public const string connectionString = "mongodb://viktor:qwerty@ds063879.mongolab.com:63879/bunniverse";
        //private const string connectionString = "mongodb://127.0.0.1";
        public void GenerateMongoData()
        {

            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("bunniverse");

            database.DropCollection("bunnies");
            database.DropCollection("ships");
            database.DropCollection("planets");
            database.DropCollection("foods");
            database.DropCollection("cargos");

            IDBFactory DBFactory = new DBFactory();
            DBFactory.CreatePlanets(client);


            Random randomNumber = new Random();

            var planets = database.GetCollection<Planet>("planets");
            foreach (var planet in planets.FindAll())
            {
                Console.Write("new Planet: " + planet.PlanetName);
                Console.WriteLine("\n");

                DBFactory.CreateShips(planet, client);
            }


            DBFactory.CreateFood();

            //var foods = database.GetCollection<Food>("foods");

            DBFactory.CreateCargos();

            //var cargos = database.GetCollection<Cargo>("cargos");

            //foreach (var cargo in cargos.FindAll())
            //{
            //    //Console.WriteLine(cargo.Ship.ShipName + " --> " + cargo.Food.FoodName + " : " + cargo.FoodQuantity + "\n");
            //}

        }

    }
}
