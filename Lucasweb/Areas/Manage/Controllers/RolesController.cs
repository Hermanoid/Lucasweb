using Lucasweb.Areas.Manage.Models;
using Lucasweb.Controllers;
using Lucasweb.DataContracts;
using Lucasweb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Lucasweb.Areas.Manage.Controllers
{
    public class RolesController : Controller
    {
        private UserIdentityManager _appIdManager;

        private IdentityContext Idb = new IdentityContext();
        private List<SelectListItem> RequestTypeOptions = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text="Id",
                    Value="User Id",
                    Selected=true
                },
                new SelectListItem()
                {
                    Text="Username",
                    Value="UserName",
                },
                new SelectListItem()
                {
                    Text="Email",
                    Value="Email"
                }
            };

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


        // GET: Manage/Roles
        public ActionResult Index()
        {
            UserSearchRequest req = new UserSearchRequest();
            req.RequestTypeOptions = RequestTypeOptions;
            return View(req);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserSearchRequest req)
        {
            req.RequestTypeOptions = RequestTypeOptions;
            try
            {
                if (ModelState.IsValid)
                {
                    AppUserId user = new AppUserId();
                    int Id = 0;
                    switch (req.RequestType)
                    {
                        case SearchType.Id:
                            if (!int.TryParse(req.SearchValue, out Id))
                            {
                                ModelState.AddModelError("SearchValue", "The Supplied User Id was not a valid number.");
                                return View(req);
                            }
                            user = Idb.Users.Find(Id);
                            break;
                        case SearchType.Username:
                            user = Idb.Users.First(AppUser => AppUser.UserName == req.SearchValue);
                            break;
                        case SearchType.Email:
                            user = Idb.Users.First(AppUser => AppUser.Email == req.SearchValue);
                            break;
                        default:
                            ModelState.AddModelError("RequestType", "The Search Type selected is invalid.");
                            break;
                    }
                    if (user == null)
                    {
                        FailedSearchMessage();
                    }
                    else
                    {
                        return RedirectToAction("Edit", new { User = user.UserName });
                    }
                }
                return View(req);
            }
            catch (InvalidOperationException e)
            {
                if (e.Message == "Sequence contains no elements")
                {
                    FailedSearchMessage();
                    return View(req);
                }
                else
                {
                    ThrowModelstateError(e);
                    return View(req);
                }
            }
            catch (Exception e)
            {
                ThrowModelstateError(e);
                return View(req);
            }
        }

        private void FailedSearchMessage()
        {
            ModelState.AddModelError("", "The Search Yielded no Results.  Ensure You typed the search Correctly, or you selected the correct Search Type.");
        }

        private void ThrowModelstateError(Exception e)
        {
            ModelState.AddModelError("", "The search failed because of:  " + e.Message);
        }

        public ActionResult Edit(string User)
        {
            AppUserId AppUser;
            try
            {
                AppUser = Idb.Users.First(user => user.UserName == User);
            }
            catch (InvalidOperationException e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, $"The supplied User ({User}) could not be found: {e.Message}");
            }

            UserRoleData URD = new UserRoleData();
            URD.UserName = AppUser.UserName;
            URD.Roles = AppUser.Roles
                .Select(role => Idb.Roles.Find(role.RoleId))
                .ToList();
            URD.Id = AppUser.Id;
            return View(URD);
        }

        public ActionResult Add(string User)
        {
            AppUserId AppUser;
            try
            {
                AppUser = Idb.Users.First(user => user.UserName == User);
            }
            catch (InvalidOperationException e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "The Supplied UserName does not exist in our database:  " + e.Message);
            }
            RoleModData RMD = new RoleModData()
            {
                RoleOptions = Convert(Idb.Roles.ToList()),
                UserId = AppUser.Id,
                UserName = AppUser.UserName
            };
            return View(RMD);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(RoleModData RMD)
        {
            if (ModelState.IsValid)
            {
                AppUserId UserFromRoute;
                try
                {
                    var Role = Idb.Roles.Find(RMD.Role.Text);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "The suppplied RoleId is invalid:  " + e.Message);
                    return View(RMD);
                }

                ExtractUserFromRoute(RMD, out UserFromRoute);
                bool UserHasRole = true;
                try
                {
                    var Role = UserFromRoute.Roles.First(role => role.RoleId == RMD.Role.Value);
                }
                catch (InvalidOperationException)
                {
                    UserHasRole = false;
                }
                catch (Exception e)
                {
                    throw new Exception($"An Unexpected Exception occurred while confirming the User '{UserFromRoute.UserName}' does not already have Role '{RMD.Role.Text}':  {Environment.NewLine}'{e.Message}'.{Environment.NewLine}  See Inner Exception for stack trace or more details.", e);
                }

                if (UserHasRole)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Conflict, $"Role to add to User {UserFromRoute.UserName} already belongs to that user.");
                }
                if (RMD.Role.Text == null)
                {
                    RMD.Role.Text = Idb.Roles.Find(RMD.Role.Value).Name;
                }
                AppIdManager.AddToRole(RMD.UserId, RMD.Role.Text);
                return RedirectToAction("Edit", new { User = RMD.UserName });

            }
            return View(RMD);
        }

        private void ExtractUserFromRoute(RoleModData RMD, out AppUserId UserFromRoute)
        {
            string RouteDataUser = (string)Request.RequestContext.RouteData.Values["User"];

            UserFromRoute = Idb.Users.First(user => user.UserName == RouteDataUser);
            RMD.UserId = UserFromRoute.Id;
            RMD.UserName = UserFromRoute.UserName;
        }

        private static List<SelectListItem> Convert(List<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> Roles)
        {
            return Roles.Select(role => new SelectListItem() { Text = role.Name, Value = role.Id }).ToList();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoleModData RMD)
        {
            if (ModelState.IsValid)
            {
                IdentityRole toCreate = new IdentityRole(RMD.RoleToCreate);
                if (Idb.Roles.Where(role => role.Name == toCreate.Name).ToList().Count > 0)
                {
                    ModelState.AddModelError("", "The Supplied Role Name Already Exists.");
                    return View(RMD);
                }
                else
                {
                    Idb.Roles.Add(toCreate);
                    Idb.SaveChanges();
                    return Redirect(TempData["returnUrl"].ToString() ?? Url.Action("Index"));
                }
            }
            return View(RMD);
        }

        public ActionResult Remove(string User, string Role)
        {
            IdentityRole IdRole;
            AppUserId AppUser;

            
            try
            {
                IdRole = Idb.Roles.First(role => role.Name == Role);
            }catch(InvalidOperationException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "The supplied role to remove does not exist.");
            }
            try
            {
                AppUser = Idb.Users.First(user => user.UserName == User);
            }catch(InvalidOperationException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "The Supplied User to remove from does not exist.");
            }



            RoleModData RMD = new RoleModData()
            {
                UserName = AppUser.UserName,
                Role = new SelectListItem()
                {
                    Text = Role
                }
            };

            return View(RMD);
        }

        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveConfirmed(string User, string Role)
        {
            if (ModelState.IsValid)
            {
                AppUserId AppUser = Idb.Users.First(user => user.UserName == User);
                AppIdManager.RemoveFromRole(AppUser.Id, Role);
                if (ViewBag.returnUrl == null)
                {
                    return RedirectToAction("Edit", new { User = User });
                }else
                {
                    return Redirect(ViewBag.returnUrl.ToString());
                }
            }

            return View();
        }
    }
}