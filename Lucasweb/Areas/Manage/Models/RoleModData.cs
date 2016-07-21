using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lucasweb.Areas.Manage.Models
{
    public class RoleModData
    {
        public string UserId { get; set; }

        public SelectListItem Role { get; set; }

        [Display(Name = "Role Name")]
        public string RoleToCreate { get; set; }

        public string UserName { get; set; }

        public List<SelectListItem> RoleOptions { get; set; }

        public SelectList RoleOptions2 { get; set; }

        [Display(Description = "The home page of where this Permission grants access to.")]
        public string URL { get; set; }

        [Display(Name ="Is Manageable", Description = "If this Role should appear on the management Home Page.")]
        public bool isManageable { get; set; }
    }
}
