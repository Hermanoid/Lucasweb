using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.Areas.Manage.Models
{
    public class UserRoleData
    {
        public List<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> Roles { get; set; }

        public string UserName { get; set; }

        public string Id { get; set; }
    }
}
