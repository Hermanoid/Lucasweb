using Lucasweb.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.Managers
{
    class HelloManager : IHelloManager
    {
        public string Hello(string name)
        {
            return "Hello " + name;
        }
    }
}
