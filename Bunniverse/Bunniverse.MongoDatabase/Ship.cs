namespace Bunniverse.MongoDatabase
{
    using System;
    using MongoDB.Bson;
    using System.Collections.Generic;
    public class Ship
    {
        public Ship()
        {
            this.Bunnies = new HashSet<Bunny>();
        }
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public float EnginePower { get; set; }

        public ICollection<Bunny> Bunnies { get; set; }
    }
}
