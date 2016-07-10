using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.Models
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password*")]
        public string Password { get; set; }

        [Required]
        [Display(Name="Username*")]
        public string UserName { get; set; }
    }
}
