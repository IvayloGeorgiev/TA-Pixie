using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunniverse
{
    public class Entity
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }
    }
}
