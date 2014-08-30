namespace Bunniverse.MongoDatabase
{
    using System;
    using MongoDB.Bson;
    public class Bunny
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }
    }
}
