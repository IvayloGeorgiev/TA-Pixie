using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunniverse.Models
{
    public class FoodGathered
    {
        public FoodGathered()
        {
            this.FoodGatheredId = Guid.NewGuid();
        }

        [BsonId]
        public Guid FoodGatheredId { get; set; }

        public Guid FoodId { get; set; }

        public int VisitID { get; set; }

        public double Quantity { get; set; }

        public virtual Food Food { get; set; }

        public virtual Visit Visit { get; set; }
    }
}
