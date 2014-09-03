namespace Bunniverse.Models
{
    using System;
    using MongoDB.Bson;
    using System.Collections.Generic;
    using MongoDB.Bson.Serialization.Attributes;
    public class Ship
    {
        public Ship()
        {
            this.Bunnies = new HashSet<Bunny>();
            this.Cargoes = new HashSet<Cargo>();
            this.Visits = new HashSet<Visit>();
            this.ShipId = Guid.NewGuid();
        }

        [BsonId]
        public Guid ShipId { get; set; }

        public string ShipName { get; set; }

        public double EnginePower { get; set; }

      //  public Guid PlanetId { get; set; }

        public virtual ICollection<Bunny> Bunnies { get; set; }

        public virtual ICollection<Cargo> Cargoes { get; set; }

        public virtual Planet Planet { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }
    }
}
