using Lucasweb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lucasweb.Controllers
{
    public class AccountController : Controller
    {
        private UserIdentityManager _userManager;

        private IdentityContext db = new IdentityContext();

        public UserIdentityManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<UserIdentityManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Account
        public ActionResult Index()
        {
            return View(db.Users.Find(""));
        }

        public void Register()
        {
            Console.WriteLine("Bob BlobStopper account creation result");
            var result = UserManager.CreateAsync(new DataContracts.AppUserId()
            {
                Id = "he43",
                Email = "bobBlobstopper@theblob.blob",
                UserId = 0,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                UserName = "bobbyBlobStopper",
                LockoutEndDateUtc = new DateTime(2016, 7, 4, 3, 2, 1)
                
            },"BOBBYBLOBBOB");
            if (result.Result.Succeeded)
            {
                Console.WriteLine("Success!!");
            }else
            {
                Console.WriteLine("Not Success!!");
            }

        }
    }
}