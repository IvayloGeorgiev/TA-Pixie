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
        public void ConvertMongoToSQL()
        {
            var connectionString = "mongodb://viktor:qwerty@ds063879.mongolab.com:63879/bunniverse";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("bunniverse");
            IDBFactory DBFactory = new DBFactory();

            using (var bunniverseSQL = new BunniverseEntities())
            {
                var planets = database.GetCollection<Planet>("planets");

                foreach (var planet in planets.FindAll())
                {
                    bunniverseSQL.Planets.Add(planet);
                }

                bunniverseSQL.SaveChanges();

                var foods = database.GetCollection<Food>("foods");

                foreach (var food in foods.FindAll())
                {
                    bunniverseSQL.Foods.Add(food);
                }

                bunniverseSQL.SaveChanges();


                var ships = database.GetCollection<Ship>("ships");

                foreach (var ship in ships.FindAll())
                {
                    bunniverseSQL.Ships.Add(ship);
                }

                bunniverseSQL.SaveChanges();


               var bunnies = database.GetCollection<Bunny>("bunnies");

               foreach (var bunny in bunnies.FindAll())
               {
                   bunniverseSQL.Bunnies.Add(bunny);
               }

                bunniverseSQL.SaveChanges();

                var cargos = database.GetCollection<Cargo>("cargos");

                foreach (var cargo in cargos.FindAll())
                {
                    bunniverseSQL.Cargoes.Add(cargo);
                }

                bunniverseSQL.SaveChanges();
            }

        }
    }
}
