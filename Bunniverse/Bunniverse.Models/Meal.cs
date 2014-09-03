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
        [BsonId]
        public int MealId { get; set; }

       // public int BunnyId { get; set; }

      //  public int FoodId { get; set; }

        public double FoodQuantity { get; set; }

        public DateTime Date { get; set; }

        public virtual Bunny Bunny { get; set; }
        public virtual Food Food { get; set; }
    }
}
