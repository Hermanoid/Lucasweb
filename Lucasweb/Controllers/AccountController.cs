using Lucasweb.Contracts;
using Lucasweb.DataContracts;
using Lucasweb.Models;
using Lucasweb.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lucasweb.Controllers
{
    public class AccountController : Controller
    {
        private UserIdentityManager _appIdManager;

        private IdentityContext db = new IdentityContext();

        public UserIdentityManager AppIdManager
        {
            get
            {
                return _appIdManager ?? HttpContext.GetOwinContext().GetUserManager<UserIdentityManager>();
            }
            private set
            {
                _appIdManager = value;
            }
        }

        private IUserManager _userDataManager;

        public IUserManager UserDataManager
        {
            get
            {
                return _userDataManager ?? ClassFactory.CreateClass<IUserManager>();
            }
            private set
            {
                _userDataManager = value;
            }
        }
        public IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }

        [Authorize]
        // GET: Account
        public ActionResult Index()
        {
            AppUserId AUI = db.Users.Find(User.Identity.GetUserId());
            User user = UserDataManager.GetUser(AUI.UserId);
            List<string> sRoles = new List<string>();
            foreach (var Role in AUI.Roles)
            {
                sRoles.Add(db.Roles.Find(Role.UserId).Name);
            }
            Tuple<AppUserId, User, List<string>> ViewModels = new Tuple<AppUserId, User, List<string>>(AUI, user, sRoles);
            return View(ViewModels);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterModel rm)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (AppIdManager.FindByName(rm.UserName) != null)
                    {
                        throw new Exception("The Username '" + rm.UserName + "' already exists.");
                    }
                    var newUser = new User()
                    {
                        FirstName = rm.FirstName,
                        LastName = rm.LastName,
                        UserName = rm.UserName,
                        Email = rm.Email
                    };
                    AppUserId AUI = new AppUserId()
                    {
                        UserName = rm.UserName,
                        Email = rm.Email,
                        UserId = ClassFactory.CreateClass<IUserManager>().CreateUser(newUser)
                    };
                    var result = AppIdManager.CreateAsync(AUI, rm.Password);
                    if (!result.Result.Succeeded)
                    {
                        throw result.Exception;
                    }
                    await SignInAsync(AUI, true);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(rm);
                }
            }
            catch (AggregateException ax)
            {
                StringBuilder Exs = new StringBuilder();
                foreach (Exception vx in ax.InnerExceptions)
                {
                    var x = vx;
                    while (x.InnerException != null) x = x.InnerException;
                    Exs.AppendLine(x.Message);

                }
                ModelState.AddModelError("", "Registration failed due to the following database errors:  " + Exs.ToString());
                return View(rm);
            }
            catch (Exception x)
            {
                ModelState.AddModelError("", "Register Failed:  " + x.Message);
                return View(rm);
            }



        }

        [AllowAnonymous]
        private async Task SignInAsync(AppUserId user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var claimsIdentity = await AppIdManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, claimsIdentity);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel lm, string returnUrl)
        {
            AppUserId AUI = AppIdManager.Find(lm.UserName, lm.Password);
            await SignInAsync(AUI, true);
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult Logout()
        {
            return View((object)User.Identity.Name);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout(SimpleStringModel Name)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index");
        }
    }
}