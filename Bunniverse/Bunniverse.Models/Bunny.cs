﻿namespace Bunniverse.Models
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.IdGenerators;
    using System.Collections.Generic;
    public class Bunny
    {
        public Bunny()
        {
            this.BunnyId = Guid.NewGuid();
        }
        [BsonId]
        public Guid BunnyId { get; set; }
        public string BunnyName { get; set; }
        //public Guid? ShipId { get; set; }

        public virtual Ship Ship { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }
    }
}