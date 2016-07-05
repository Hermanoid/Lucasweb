using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.Models
{
    public class RegisterModel
    {
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name ="Username*")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password*")]
        public string Password { get; set; }

        [Required]
        [Compare("Password",ErrorMessage="Passwords must match.")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password*")]
        public string ConfirmPassword { get; set; }

        [Display(Name ="Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }




    }
}
