using Bunniverse.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunniverse.Contracts
{
    interface IDBFactory
    {
        void CreateBunnies(Ship ship, MongoClient client);

        void CreateShips(Planet planet, MongoClient client);

        void CreateCargos();

        void CreatePlanets(MongoClient client);

        void CreateFood();
    }
}
