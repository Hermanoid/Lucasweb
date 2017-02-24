using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.DataContracts
{
    public class UserRole : IdentityRole
    {
        public UserRole() : base() { }
        public UserRole(string name) : base() { }

        /// <summary>
        /// The home page of whatever this role grants access to.  e.g.  Manage/Users for User Management Role
        /// </summary>
        public string  HomeUrl {get; set; }


        public bool isManageable { get; set; }
    }
}
