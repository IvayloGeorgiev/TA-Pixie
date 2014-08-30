namespace Bunniverse.MongoDatabase
{
    using System;
    using MongoDB.Bson;
    using System.Collections.Generic;
    public class Planet
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
        public int Z { get; set; }

        ICollection<Ship> Ships { get; set; }
    }
}
