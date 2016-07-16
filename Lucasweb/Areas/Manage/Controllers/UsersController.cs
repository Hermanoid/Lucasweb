using Lucasweb.Contracts;
using Lucasweb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lucasweb.Areas.Manage.Controllers
{
    public class UsersController : Controller
    {
        private IUserManager _userManager;

        public IUserManager UserManager
        {
            get
            {
                return _userManager ?? ClassFactory.CreateClass<IUserManager>();
            }
        }


        // GET: Manage/Users
        public ActionResult Index(int F_index, int L_index)
        {
            var users = UserManager.GetUsers(F_index, L_index);
            foreach(var user in users)
            {
                user.UniqueEncryptPassword = null;
            }
            return View(users);
        }
    }
}