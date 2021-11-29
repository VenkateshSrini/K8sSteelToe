using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database
{
    public interface IDatabase
    {
        public bool Persist();
        public List<string> List();

    }
}
