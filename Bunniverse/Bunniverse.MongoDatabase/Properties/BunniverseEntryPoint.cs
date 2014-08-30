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
            var database = server.GetDatabase("test");
            var entities = database.GetCollection<Entity>("entities");
            Console.WriteLine(entities);
            var entity = new Entity { Name = "Tom" };
            entities.Insert(entity);
            var id = entity.Id; // Insert will set the Id if necessary (as it was in this example)
            foreach (var item in entities.FindAll())
            {
                Console.WriteLine(item.Name);
            }

        }
    }
}
