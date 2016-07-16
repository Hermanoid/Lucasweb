using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.Areas.Manage.Models
{
    public class RoleModData
    {
        public string UserId { get; set; }

        public System.Web.Mvc.SelectListItem Role { get; set; }

        /// <summary>
        /// For Creating new Roles specifically
        /// </summary>
        public string RoleToCreate { get; set; }

        public string UserName { get; set; }

        public List<System.Web.Mvc.SelectListItem> RoleOptions { get; set; }
    }
}
