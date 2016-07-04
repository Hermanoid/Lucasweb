using Lucasweb.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.Engines
{
    public class CharacterUtils : ICharacterUtils
    {
        public int addAsciiValsOf(string message)
        {
            char[] chars = message.ToCharArray();
            int total = 0;
            foreach (char c in chars)
            {
                total += (int)c;
            }
            return total;
        }
    }
}
