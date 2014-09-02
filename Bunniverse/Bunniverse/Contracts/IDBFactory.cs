using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunniverse.Contracts
{
    interface IDBFactory
    {
        void CreateBunnies();

        void CreateShips();

        void CreateCargos();

        void CreatePlanets();

        void CreateFood();
    }
}
