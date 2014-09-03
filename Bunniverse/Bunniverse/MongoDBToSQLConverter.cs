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
            var bunnies = database.GetCollection<Bunny>("bunnies");
            IDBFactory DBFactory = new DBFactory();

            //DBFactory.CreateBunnies();
            using (var bunniverseSQL = new BunniverseEntities())
            {
                foreach (var bunny in bunnies.FindAll())
                {
                    bunniverseSQL.Bunnies.Add(bunny);
                }
                Console.WriteLine(bunniverseSQL.Bunnies.ToList().Count);
                foreach (var item in bunniverseSQL.Bunnies)
                {
                    Console.WriteLine(item.BunnyName);
                }
                bunniverseSQL.SaveChanges();
            }

        }
    }
}
