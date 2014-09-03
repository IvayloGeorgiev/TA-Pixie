using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunniverse.Contracts
{
    interface IMongoDBToSQLConverter
    {
        void ConvertMongoToSQL();
    }
}
