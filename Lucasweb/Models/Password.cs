using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.Models
{
    public class Password
    {

        [Required]
        public string password { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string message { get; set; }

        [Required]
        [Display(Description = "Encrypt")]
        public bool isEncrypt { get; set; }
    }
}
