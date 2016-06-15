using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lucasweb.Contracts;
using Lucasweb.Utilities;
using Lucasweb.Models;

namespace Lucasweb.Controllers
{
    public class EncrypterController : Controller
    {
        // GET: Encrypter
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pins/Create
        public ActionResult Pin()
        {
            return View();
        }

        // POST: Pins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pin([Bind(Include = "PinId,pin,message")] Pin pin)
        {
            int UserPin = 0;
            if (ModelState.IsValid)
            {
                
                if (!int.TryParse(pin.message,out UserPin))
                {
                    TempData["ErrorMessage"] = string.Format("Entered Pin is not a number. ({0})", pin.pin);
                    return RedirectToAction("Error");
                }
                TempData["Result"] = ClassFactory.CreateClass<IEncryptManager>().PinEncrypt(pin.message,UserPin);
                return RedirectToAction("Index");
            }

            return View(pin);
        }
        public ActionResult Result()
        {
            ViewData["Result"] = TempData["Result"];
            return View();
        }
    }
}