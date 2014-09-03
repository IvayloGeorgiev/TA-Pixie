using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunniverse.Data
{
    public class ShipsTravel
    {
        public int ID { get; set; }
        public string ShipName { get; set; }
        public float TotalDistance { get; set; }
        public int PlanetsVisited { get; set; }
    }
}
