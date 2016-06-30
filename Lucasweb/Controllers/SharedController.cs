using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lucasweb.Controllers
{
    public class SharedController : Controller
    {

        [ActionName("_DropDownStuff")]
        public PartialViewResult _DropDownStuff()
        {
            ViewData["DropDownStuff"] = "Drop down worked to.";
            return PartialView();
        }
    }
}
