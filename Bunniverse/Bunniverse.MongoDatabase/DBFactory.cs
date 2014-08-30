namespace Bunniverse.MongoDatabase
{
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MongoDatabase.Contracts;
    using MongoDB.Driver.Linq;
    public class DBFactory : IDBFactory
    {
        public void CreateBunnies()
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("Bunniverse");
            var bunnies = database.GetCollection<Bunny>("bunnies");
            for (int i = 0; i < 1000; i++)
            {
                string bunnyName = String.Format("IvoBunny" + i);
                var bunny = new Bunny { Name = bunnyName };
                bunnies.Insert(bunny);
            }
        }

        public void CreateShips()
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("Bunniverse");
            var ships = database.GetCollection<Ship>("ships");

            var viktorShip = new Ship { Name = "ViktorShip", EnginePower = 500000 };
            var nikiShip = new Ship { Name = "NikiShip", EnginePower = 500 };
            var evlogiShip = new Ship { Name = "EvlogiShip", EnginePower = 50 };
            var ivoShip = new Ship { Name = "IvoShip", EnginePower = 0.1f };
            var donchoShip = new Ship { Name = "DonchoShip", EnginePower = 0.1f };

            var bunnies = database.GetCollection<Bunny>("bunnies");
            int bunnyCounter = 0;

            foreach (var bunny in bunnies.FindAll())
            {
                if (bunnyCounter < 200)
                {
                    viktorShip.Bunnies.Add(bunny);
                }
                else if (bunnyCounter < 400)
                {
                    nikiShip.Bunnies.Add(bunny);
                }
                else if (bunnyCounter < 600)
                {
                    evlogiShip.Bunnies.Add(bunny);
                }
                else if (bunnyCounter < 800)
                {
                    ivoShip.Bunnies.Add(bunny);
                }
                else if (bunnyCounter < 1000)
                {
                    donchoShip.Bunnies.Add(bunny);
                }
                bunnyCounter++;
            }

            ships.Insert(viktorShip);
            ships.Insert(nikiShip);
            ships.Insert(evlogiShip);
            ships.Insert(ivoShip);
            ships.Insert(donchoShip);
        }

        public void CreateCargos()
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("Bunniverse");
            var cargos = database.GetCollection<Cargo>("cargos");
            var ships = database.GetCollection<Ship>("ships");
            var foods = database.GetCollection<Food>("foods");
            Random randomNumber = new Random();

            foreach (var ship in ships.FindAll())
            {
                foreach (var food in foods.FindAll())
                {
                    var cargo = new Cargo
                    {
                        Ship = ship,
                        Food = food,
                        FoodQuantity = randomNumber.Next(1, 100)
                    };

                    cargos.Insert(cargo);
                }
            }
        }

        public void CreatePlanets()
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("Bunniverse");
            var planets = database.GetCollection<Planet>("planets");

            Random randomNumber = new Random();

            var viktorPlanet = new Planet
            {
                Name = "ViktorPlanet",
                X = randomNumber.Next(0, 1000),
                Y = randomNumber.Next(0, 1000),
                Z = randomNumber.Next(0, 1000)
            };

            var nikiPlanet = new Planet
            {
                Name = "NikiPlanet",
                X = randomNumber.Next(0, 1000),
                Y = randomNumber.Next(0, 1000),
                Z = randomNumber.Next(0, 1000)
            };

            var evlogiPlanet = new Planet
            {
                Name = "EvlogiPlanet",
                X = randomNumber.Next(0, 1000),
                Y = randomNumber.Next(0, 1000),
                Z = randomNumber.Next(0, 1000)
            };

            var ivoPlanet = new Planet
            {
                Name = "IvoPlanet",
                X = randomNumber.Next(0, 1000),
                Y = randomNumber.Next(0, 1000),
                Z = randomNumber.Next(0, 1000)
            };

            var donchoPlanet = new Planet
            {
                Name = "DonchoPlanet",
                X = randomNumber.Next(0, 1000),
                Y = randomNumber.Next(0, 1000),
                Z = randomNumber.Next(0, 1000)
            };

            var ships = database.GetCollection<Ship>("ships");

            var viktorShip = ships.AsQueryable<Ship>().FirstOrDefault(s => s.Name == "ViktorShip");
            var nikiShip = ships.AsQueryable<Ship>().FirstOrDefault(s => s.Name == "NikiShip");
            var evlogiShip = ships.AsQueryable<Ship>().FirstOrDefault(s => s.Name == "EvlogiShip");
            var ivoShip = ships.AsQueryable<Ship>().FirstOrDefault(s => s.Name == "IvoShip");
            var donchoShip = ships.AsQueryable<Ship>().FirstOrDefault(s => s.Name == "DonchoShip");

            viktorPlanet.Ships.Add(viktorShip);
            nikiPlanet.Ships.Add(nikiShip);
            evlogiPlanet.Ships.Add(evlogiShip);
            ivoPlanet.Ships.Add(ivoShip);
            donchoPlanet.Ships.Add(donchoShip);

            planets.Insert(viktorPlanet);
            planets.Insert(nikiPlanet);
            planets.Insert(evlogiPlanet);
            planets.Insert(ivoPlanet);
            planets.Insert(donchoPlanet);
        }

        public void CreateFood()
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("Bunniverse");
            var foods = database.GetCollection<Food>("foods");

            var carrot = new Food { Name = "Carrot" };
            var cabbage = new Food { Name = "Cabbage" };
            var bunny = new Food { Name = "Bunny" };
            var bunnyPizza = new Food { Name = "BunyPizza" };
            var bunnyDuner = new Food { Name = "BunnyDuner" };
            var pork = new Food { Name = "Pork" };

            foods.Insert(carrot);
            foods.Insert(cabbage);
            foods.Insert(bunny);
            foods.Insert(bunnyPizza);
            foods.Insert(bunnyDuner);
            foods.Insert(pork);

        }
    }
}
