namespace Bunniverse.MongoDatabase
{
    using System;
    using MongoDB.Bson;
    using System.Collections.Generic;
    public class Planet
    {
        public Planet()
        {
            this.Ships = new HashSet<Ship>();
        }
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public float X { get; set; }

        public float Y { get; set; }
        public float Z { get; set; }

        public ICollection<Ship> Ships { get; set; }
    }
}
