using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunniverse.Models;

namespace Bunniverse.Data
{
    public class BunniverseEntities : DbContext
    {
        public virtual DbSet<Bunny> Bunnies { get; set; }
        public virtual DbSet<Cargo> Cargoes { get; set; }
        public virtual DbSet<FoodGathered> FoodGathereds { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<Ship> Ships { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
    }
}
