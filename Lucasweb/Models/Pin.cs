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

        [Required]
        public string pin { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string message { get; set; }

        [Required]
        [Display(Description ="Encrypt")]
        public bool isEncrypt { get; set; }
    }
}
