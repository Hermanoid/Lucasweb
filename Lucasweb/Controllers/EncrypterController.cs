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

                if (!int.TryParse(UserPin.pin, out UserPinNum))
                {
                    TempData["ErrorMessage"] = string.Format("Entered Pin is not a number. ({0})", UserPin.pin);
                    return RedirectToAction("Error");
                }

                IEncryptManager IEM = ClassFactory.CreateClass<IEncryptManager>();
                if (UserPin.isEncrypt)
                {
                    TempData["Result"] = IEM.PinEncrypt(UserPin.message, UserPinNum);
                }
                else
                {
                    TempData["Result"] = IEM.PinDecrypt(UserPin.message, UserPinNum);
                }

                Dictionary<string, string> ExtraData = new Dictionary<string, string>();
                ExtraData["Pin Used:  "] = UserPin.pin;
                ExtraData["For Message:  "] = UserPin.message;
                TempData["ExtraInfo"] = ExtraData;

                TempData["BackLink"] = "Pin";
                return RedirectToAction("Result");
            }

            return View(UserPin);
        }

        public ActionResult Generic()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Generic(GenericModel SModel)
        {
            if (ModelState.IsValid)
            {
                IEncryptManager IEM = ClassFactory.CreateClass<IEncryptManager>();
                if (SModel.isEncrypt)
                {
                    TempData["Result"] = IEM.GenericEncrypt(SModel.message);
                }
                else
                {
                    TempData["Result"] = IEM.GenericDecrypt(SModel.message);
                }
                TempData["ExtraInfo"] = new Dictionary<string, string>() { { "Original Message:  ", SModel.message } };
                TempData["BackLink"] = "Generic";
                return RedirectToAction("Result");
            }

            return View(SModel);
        }

        public ActionResult Password()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Password(Password PassModel)
        {
            if (ModelState.IsValid)
            {
                IEncryptManager IEM = ClassFactory.CreateClass<IEncryptManager>();
                if (PassModel.isEncrypt)
                {
                    TempData["Result"] = IEM.PasswordEncrypt(PassModel.message,PassModel.password);
                }else
                {
                    TempData["Result"] = IEM.PasswordDecrypt(PassModel.message, PassModel.password);
                }
                Dictionary<string, string> ExtraInfo = new Dictionary<string, string>();
                ExtraInfo["Password Used:  "] = PassModel.password;
                ExtraInfo["Message:  "] = PassModel.message;
                if (PassModel.isEncrypt)
                {
                    ExtraInfo["Mode:  "] = "Encrypt";
                }
                else
                {
                    ExtraInfo["Mode:  "] = "Decrypt";
                }
                TempData["ExtraInfo"] = ExtraInfo;
                TempData["BackLink"] = "Password";
                return RedirectToAction("Result");
            }
            return View();


        }

        public ActionResult Result()
        {
            ViewData["Result"] = TempData["Result"];
            ViewData["BackLink"] = TempData["BackLink"];
            ViewData["ExtraInfo"] = TempData["ExtraInfo"];
            return View();
        }
    }
}