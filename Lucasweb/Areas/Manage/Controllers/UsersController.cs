using Lucasweb.Areas.Manage.Models;
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
        //Values Per Users Page, shorted because it will be used a lot
        private const int VPUP = 50;

        private IUserManager _userManager;

        public IUserManager UserManager
        {
            get
            {
                return _userManager ?? ClassFactory.CreateClass<IUserManager>();
            }
        }


        //[Authorize(Roles ="Admin,UserAccesor")]
        //// GET: Manage/Users
        //public ActionResult Index(int F_index, int L_index)
        //{
        //    var users = UserManager.GetUsers(F_index, L_index);
        //    foreach(var user in users)
        //    {
        //        user.UniqueEncryptPassword = null;
        //    }
        //    UsersModel toReturn = new UsersModel()
        //    {
        //        Users = users,
        //        Last = new FandL_indexPair(),
        //        Next = new FandL_indexPair()
        //    };

        //    if (F_index - VPUP < 0)
        //    {
        //        toReturn.Last.F_index = 0;
        //    }else
        //    {
        //        toReturn.Last.F_index = F_index - VPUP;
        //    }

        //    toReturn.Last.L_index = F_index;
        //    toReturn.Next.F_index = L_index;

        //    int totalUsers = ClassFactory.CreateClass<IUserManager>().TotalUsers();
        //    if (L_index + VPUP > totalUsers)
        //    {
        //        toReturn.Next.L_index = totalUsers;
        //    }
        //    else
        //    {
        //        toReturn.Next.L_index = L_index + VPUP;
        //    }

        //    return View(toReturn);
        //}
    }
}