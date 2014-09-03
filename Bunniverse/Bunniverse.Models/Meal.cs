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
            this.MealId = Guid.NewGuid();
        }

        [BsonId]
        public Guid MealId { get; set; }

        //public Guid BunnyId { get; set; }

       // public Guid FoodId { get; set; }

        public double FoodQuantity { get; set; }

        public DateTime Date { get; set; }

        public virtual Bunny Bunny { get; set; }
        public virtual Food Food { get; set; }
    }
}
