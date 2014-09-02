namespace Bunniverse.Models
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.IdGenerators;
    public class Cargo
    {
        public Cargo()
        {
            this.CargoId = Guid.NewGuid();
        }

        [BsonId]
        public Guid CargoId { get; set; }

        public virtual Ship Ship { get; set; }

        public virtual Food Food { get; set; }

        public double FoodQuantity { get; set; }

    }
}
