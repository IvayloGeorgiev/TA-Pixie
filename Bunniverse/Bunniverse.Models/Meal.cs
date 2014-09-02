using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunniverse.Models
{
    public class Meal
    {
        public Meal()
        {
            this.MealID = Guid.NewGuid();
        }

        [BsonId]
        public Guid MealID { get; set; }

        public Guid BunnyID { get; set; }

        public Guid FoodID { get; set; }

        public double FoodQuantity { get; set; }

        public DateTime Date { get; set; }

        public virtual Bunny Bunny { get; set; }
        public virtual Food Food { get; set; }
    }
}
