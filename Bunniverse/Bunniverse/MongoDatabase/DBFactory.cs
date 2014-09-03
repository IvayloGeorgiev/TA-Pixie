namespace Bunniverse.MongoDatabase
{
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;
    using MongoDB.Driver.Linq;
    using Bunniverse.Models;
    public class DBFactory : IDBFactory
    {
        private const string connectionString = "mongodb://viktor:qwerty@ds063879.mongolab.com:63879/bunniverse";

        public void CreatePlanets(MongoClient client)
        {
            //var connectionString = "mongodb://viktor:qwerty@ds063879.mongolab.com:63879/bunniverse";
            //var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("bunniverse");
            var planets = database.GetCollection<Planet>("planets");

            Random randomNumber = new Random();

            var viktorPlanet = new Planet()
            {
                PlanetId = 1,
                PlanetName = "ViktorPlanet",
                X = randomNumber.Next(0, 1000),
                Y = randomNumber.Next(0, 1000),
                Z = randomNumber.Next(0, 1000)
            };

            var nikiPlanet = new Planet()
            {
                PlanetId = 2,
                PlanetName = "NikiPlanet",
                X = randomNumber.Next(0, 1000),
                Y = randomNumber.Next(0, 1000),
                Z = randomNumber.Next(0, 1000)
            };

            var evlogiPlanet = new Planet()
            {
                PlanetId = 3,
                PlanetName = "EvlogiPlanet",
                X = randomNumber.Next(0, 1000),
                Y = randomNumber.Next(0, 1000),
                Z = randomNumber.Next(0, 1000)
            };

            var ivoPlanet = new Planet()
            {
                PlanetId = 4,
                PlanetName = "IvoPlanet",
                X = randomNumber.Next(0, 1000),
                Y = randomNumber.Next(0, 1000),
                Z = randomNumber.Next(0, 1000)
            };

            var donchoPlanet = new Planet()
            {
                PlanetId = 5,
                PlanetName = "DonchoPlanet",
                X = randomNumber.Next(0, 1000),
                Y = randomNumber.Next(0, 1000),
                Z = randomNumber.Next(0, 1000)
            };

            planets.Insert(viktorPlanet);
            planets.Insert(nikiPlanet);
            planets.Insert(evlogiPlanet);
            planets.Insert(ivoPlanet);
            planets.Insert(donchoPlanet);
        }
        public void CreateShips(Planet planet, MongoClient client)
        {
            Random randomNumber = new Random();
            var server = client.GetServer();
            var database = server.GetDatabase("bunniverse");
            var ships = database.GetCollection<Ship>("ships");
            var ship = new Ship {ShipId = planet.PlanetId, ShipName = "Ship" + planet.PlanetId, EnginePower = randomNumber.Next(1, 100), PlanetId = planet.PlanetId, Planet = planet };
            CreateBunnies(ship, client);
            ships.Insert(ship);
        }
        public void CreateBunnies(Ship ship, MongoClient client)
        {
            var server = client.GetServer();
            var database = server.GetDatabase("bunniverse");
            var bunnies = database.GetCollection<Bunny>("bunnies");
            for (int i = 0; i < 20; i++)
            {
                string bunnyName = String.Format("Bunny{0}", (i + (20 * (ship.ShipId - 1))));
                var bunny = new Bunny {BunnyId=i+100*ship.ShipId,  BunnyName = bunnyName, ShipId = ship.ShipId, Ship = ship };
                bunnies.Insert(bunny);
            }
        }

        public void CreateCargos()
        {
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("bunniverse");
            var cargos = database.GetCollection<Cargo>("cargos");
            var ships = database.GetCollection<Ship>("ships");
            var foods = database.GetCollection<Food>("foods");
            Random randomNumber = new Random();
            var id = 1;
            foreach (var ship in ships.FindAll())
            {
                foreach (var food in foods.FindAll())
                {

                    var cargo = new Cargo
                    {
                        CargoId = id,
                        ShipId = ship.ShipId,
                        FoodId = food.FoodId,
                        FoodQuantity = randomNumber.Next(1, 100),
                        Ship = ship
                    };
                    id++;
                    cargos.Insert(cargo);
                }
            }
        }



        public void CreateFood()
        {
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("bunniverse");
            var foods = database.GetCollection<Food>("foods");

            var carrot = new Food() {FoodId =1, FoodName = "Carrot" };
            var cabbage = new Food() {FoodId =2, FoodName = "Cabbage" };
            var bunny = new Food() {FoodId =3, FoodName = "Bunny" };
            var bunnyPizza = new Food() { FoodId =4, FoodName = "BunnyPizza" };
            var bunnyDuner = new Food() {FoodId =5,  FoodName = "BunnyDuner" };
            var pork = new Food() {FoodId =6,  FoodName = "Pork" };

            foods.Insert(carrot);
            foods.Insert(cabbage);
            foods.Insert(bunny);
            foods.Insert(bunnyPizza);
            foods.Insert(bunnyDuner);
            foods.Insert(pork);

        }

    }
}
