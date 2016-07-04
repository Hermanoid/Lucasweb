using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.DataContracts
{
    public class UserRole : IdentityRole
    {
        public UserRole() : base() { }
        public UserRole(string name) : base() { }


    }
}
