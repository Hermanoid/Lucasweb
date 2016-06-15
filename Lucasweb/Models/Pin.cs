using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.Models
{
    public class Pin
    {
        public int PinId { get; set; }


        public string pin { get; set; }

        [DataType(DataType.MultilineText)]
        public string message { get; set; }
    }
}
