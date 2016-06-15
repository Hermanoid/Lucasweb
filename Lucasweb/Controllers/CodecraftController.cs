using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lucasweb.Controllers
{
    public class CodecraftController : Controller
    {
        // GET: Codecraft
        public ActionResult Index()
        {
            return View();
        }
        
        //public ActionResult Week(int WeekId, string HtmlFile)
        //{
        //    string Html = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + "/Week" + WeekId.ToString() + "/" + HtmlFile);
        //    if (Html == null)
        //    {
        //        throw new HttpException(404, "Could not find "+ Directory.GetCurrentDirectory() + "/Week" + WeekId.ToString() + "/" + HtmlFile);
        //    }

        //    ViewData["Html"] = Html;

        //    return View();

        //}
    }
}