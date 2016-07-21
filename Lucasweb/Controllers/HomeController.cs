using Lucasweb.Contracts;
using Lucasweb.DataContracts;
using Lucasweb.Models;
using Lucasweb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lucasweb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Project> Projects = ClassFactory.CreateClass<IProjectManager>().GetHomeProjects();
            return View(Projects);
        }

        public ActionResult Projects()
        {
            return View(ClassFactory.CreateClass<IProjectManager>().GetProjects());
        }

        public ActionResult About()
        {
            return View();
        }
    }
}