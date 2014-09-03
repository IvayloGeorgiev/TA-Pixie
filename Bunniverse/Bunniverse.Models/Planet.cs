namespace Bunniverse.Models
{
    using System;
    using MongoDB.Bson;
    using System.Collections.Generic;
    using MongoDB.Bson.Serialization.Attributes;
    public class Planet
    {
        private ICollection<Ship> ships;
        public Planet()
        {
            this.ships = new HashSet<Ship>();
            this.Visits = new HashSet<Visit>();
          //  this.PlanetId = Guid.NewGuid();
        }

        [BsonId]
        public int PlanetId { get; set; }

        public string PlanetName { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public virtual ICollection<Ship> Ships
        {
            get { return this.ships; }
            set { this.ships = value; }
        }

        public virtual ICollection<Visit> Visits { get; set; }
    }
}
