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
        public void CreateBunnies()
        {
            var connectionString = "mongodb://viktor:qwerty@ds063879.mongolab.com:63879/bunniverse";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("bunniverse");
            var bunnies = database.GetCollection<Bunny>("bunnies");
            for (int i = 0; i < 1000; i++)
            {
                string bunnyName = String.Format("IvoBunny" + i);
                var bunny = new Bunny { BunnyName = bunnyName,BunnyId = i };
                bunnies.Insert(bunny);
            }
        }

        public void CreateShips()
        {
            var connectionString = "mongodb://viktor:qwerty@ds063879.mongolab.com:63879/bunniverse";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("bunniverse");
            var ships = database.GetCollection<Ship>("ships");

            var viktorShip = new Ship { ShipName = "ViktorShip", EnginePower = 500000,ShipId=0 };
            var nikiShip = new Ship { ShipName = "NikiShip", EnginePower = 500, ShipId = 1 };
            var evlogiShip = new Ship { ShipName = "EvlogiShip", EnginePower = 50, ShipId = 2};
            var ivoShip = new Ship { ShipName = "IvoShip", EnginePower = 0.1f, ShipId = 3 };
            var donchoShip = new Ship { ShipName = "DonchoShip", EnginePower = 0.1f, ShipId = 4 };

            var bunnies = database.GetCollection<Bunny>("bunnies");
            int bunnyCounter = 0;

            foreach (var bunny in bunnies.FindAll())
            {
                if (bunnyCounter < 200)
                {
                    viktorShip.Bunnies.Add(bunny);
                    //bunny.Ship = viktorShip;
                   // bunny.ShipId = viktorShip.ShipId;
                }
                else if (bunnyCounter < 400)
                {
                    nikiShip.Bunnies.Add(bunny);
                    //bunny.Ship = nikiShip;
                   // bunny.ShipId = nikiShip.ShipId;
                }
                else if (bunnyCounter < 600)
                {
                    evlogiShip.Bunnies.Add(bunny);
                  //  bunny.Ship = evlogiShip;
                   // bunny.ShipId = evlogiShip.ShipId;
                }
                else if (bunnyCounter < 800)
                {
                    ivoShip.Bunnies.Add(bunny);
                  //  bunny.Ship = ivoShip;
                   // bunny.ShipId = ivoShip.ShipId;
                }
                else if (bunnyCounter < 1000)
                {
                    donchoShip.Bunnies.Add(bunny);
                   // bunny.Ship = donchoShip;
                   // bunny.ShipId = donchoShip.ShipId;
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
            var connectionString = "mongodb://viktor:qwerty@ds063879.mongolab.com:63879/bunniverse";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("bunniverse");
            var cargos = database.GetCollection<Cargo>("cargos");
            var ships = database.GetCollection<Ship>("ships");
            var foods = database.GetCollection<Food>("foods");
            Random randomNumber = new Random();
            int idCounter =1;
            foreach (var ship in ships.FindAll())
            {
                foreach (var food in foods.FindAll())
                {
                    var cargo = new Cargo
                    {
                        Ship = ship,
                        Food = food,
                        FoodQuantity = randomNumber.Next(1, 100),
                        CargoId= idCounter
                    };

                    cargos.Insert(cargo);
                    idCounter++;
                }
            }
        }

        public void CreatePlanets()
        {
            var connectionString = "mongodb://viktor:qwerty@ds063879.mongolab.com:63879/bunniverse";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("bunniverse");
            var planets = database.GetCollection<Planet>("planets");

            Random randomNumber = new Random();

            var viktorPlanet = new Planet()
            {               
                PlanetName = "ViktorPlanet",
                X = randomNumber.Next(0, 1000),
                Y = randomNumber.Next(0, 1000),
                Z = randomNumber.Next(0, 1000),
                PlanetId=1
            };

            var nikiPlanet = new Planet()
            {
                PlanetName = "NikiPlanet",
                X = randomNumber.Next(0, 1000),
                Y = randomNumber.Next(0, 1000),
                Z = randomNumber.Next(0, 1000),
                PlanetId=2
            };

            var evlogiPlanet = new Planet()
            {
                PlanetName = "EvlogiPlanet",
                X = randomNumber.Next(0, 1000),
                Y = randomNumber.Next(0, 1000),
                Z = randomNumber.Next(0, 1000),
                PlanetId = 3
            };

            var ivoPlanet = new Planet()
            {
                PlanetName = "IvoPlanet",
                X = randomNumber.Next(0, 1000),
                Y = randomNumber.Next(0, 1000),
                Z = randomNumber.Next(0, 1000),
                PlanetId = 4
            };

            var donchoPlanet = new Planet()
            {
                PlanetName = "DonchoPlanet",
                X = randomNumber.Next(0, 1000),
                Y = randomNumber.Next(0, 1000),
                Z = randomNumber.Next(0, 1000),
                PlanetId = 5
            };

            var ships = database.GetCollection<Ship>("ships");
            var viktorShip = ships.AsQueryable<Ship>().FirstOrDefault(s => s.ShipName == "ViktorShip");
            var nikiShip = ships.AsQueryable<Ship>().FirstOrDefault(s => s.ShipName == "NikiShip");
            var evlogiShip = ships.AsQueryable<Ship>().FirstOrDefault(s => s.ShipName == "EvlogiShip");
            var ivoShip = ships.AsQueryable<Ship>().FirstOrDefault(s => s.ShipName == "IvoShip");
            var donchoShip = ships.AsQueryable<Ship>().FirstOrDefault(s => s.ShipName == "DonchoShip");

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
            var connectionString = "mongodb://viktor:qwerty@ds063879.mongolab.com:63879/bunniverse";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("bunniverse");
            var foods = database.GetCollection<Food>("foods");

            var carrot = new Food() { FoodName = "Carrot",FoodId=1 };
            var cabbage = new Food() { FoodName = "Cabbage", FoodId = 2 };
            var bunny = new Food() { FoodName = "Bunny", FoodId = 3 };
            var bunnyPizza = new Food() { FoodName = "BunnyPizza", FoodId= 4 };
            var bunnyDuner = new Food() { FoodName = "BunnyDuner", FoodId = 5 };
            var pork = new Food() { FoodName = "Pork", FoodId = 6 };

            foods.Insert(carrot);
            foods.Insert(cabbage);
            foods.Insert(bunny);
            foods.Insert(bunnyPizza);
            foods.Insert(bunnyDuner);
            foods.Insert(pork);

        }
    }
}
