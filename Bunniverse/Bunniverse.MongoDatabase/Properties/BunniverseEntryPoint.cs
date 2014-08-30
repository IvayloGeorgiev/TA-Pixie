namespace Bunniverse.MongoDatabase
{
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using MongoDB.Driver.GridFS;
    using MongoDB.Driver.Linq;
    using System;

    class BunniverseEntryPoint
    {
        static void Main(string[] args)
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("Bunniverse");
            var bunnies = database.GetCollection<Bunny>("bunnies");
            var bunny = new Bunny { Name = "IvoBunny" };
            bunnies.Insert(bunny);
            var ships = database.GetCollection<Ship>("ships");
            var ship = new Ship { Name = "Ship1", EnginePower = 5 };
           
            foreach (var item in bunnies.FindAll())
            {
                ship.Bunnies.Add(item);
            }
            ships.Insert(ship);
            foreach (var currentShip in ships.FindAll())
            {
                Console.WriteLine("Ship --> ");
                foreach (var currentBunny in ship.Bunnies)
                {
                    Console.Write(currentBunny.Name + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
