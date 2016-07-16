using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.Areas.Manage.Models
{
    public class UserSearchRequest
    {
        [Required]
        public string SearchValue { get; set; }

        [Required]
        public SearchType RequestType { get; set; }

        public List<System.Web.Mvc.SelectListItem> RequestTypeOptions { get; set; }
    }
}
