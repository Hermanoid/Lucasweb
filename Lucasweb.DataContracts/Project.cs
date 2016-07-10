using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.DataContracts
{
    public class Project
    {
        public bool isGlyph { get; set; }

        public string glyphClass { get; set; }

        public string imgSrc { get; set; }

        public string URL { get; set; }

        public string DisplayName { get; set; }
        public int ProjectId { get; set; }

    }
}
