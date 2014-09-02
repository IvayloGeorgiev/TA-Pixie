namespace Bunniverse.Models
{
    using System;
    using MongoDB.Bson;
    using System.Collections.Generic;
    using MongoDB.Bson.Serialization.Attributes;
    public class Food
    {
        public Food()
        {
            this.Cargoes = new HashSet<Cargo>();
            this.FoodGathereds = new HashSet<FoodGathered>();
            this.Meals = new HashSet<Meal>();
            this.FoodID = Guid.NewGuid();
        }
        [BsonId]
        public Guid FoodID { get; set; }
        public string FoodName { get; set; }

        public virtual ICollection<Cargo> Cargoes { get; set; }

        public virtual ICollection<FoodGathered> FoodGathereds { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }
    }
}
