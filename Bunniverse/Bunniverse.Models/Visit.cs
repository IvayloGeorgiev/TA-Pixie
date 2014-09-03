using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunniverse.Models
{
    public class Visit
    {
        public Visit()
        {
            this.FoodGathereds = new HashSet<FoodGathered>();
            this.VisitId = Guid.NewGuid();
        }

        [BsonId]
        public Guid VisitId { get; set; }

    //    public Guid PlanetId { get; set; }

      //  public Guid? ShipId { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<FoodGathered> FoodGathereds { get; set; }

        public virtual Planet Planet { get; set; }

        public virtual Ship Ship { get; set; }
    }
}
