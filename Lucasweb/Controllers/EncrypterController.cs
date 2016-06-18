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
        public ActionResult Pin([Bind(Include = "PinID,isEncrypt,pin,message")] Pin UserPin)
        {
            int UserPinNum;
            if (ModelState.IsValid)
            {
                
                if (!int.TryParse(UserPin.pin,out UserPinNum))
                {
                    TempData["ErrorMessage"] = string.Format("Entered Pin is not a number. ({0})", UserPin.pin);
                    return RedirectToAction("Error");
                }

                IEncryptManager IEM = ClassFactory.CreateClass<IEncryptManager>();
                if (UserPin.isEncrypt)
                {
                    TempData["Result"] = IEM.PinEncrypt(UserPin.message, UserPinNum);
                }else
                {
                    TempData["Result"] = IEM.PinDecrypt(UserPin.message, UserPinNum);
                }
                
                TempData["BackLink"] = "Pin";
                return RedirectToAction("Result");
            }

            return View(UserPin);
        }
        public ActionResult Result()
        {
            ViewData["Result"] = TempData["Result"];
            ViewData["BackLink"] = TempData["BackLink"];
            return View();
        }
    }
}