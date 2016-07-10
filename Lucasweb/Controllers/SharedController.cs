using Lucasweb.Contracts;
using Lucasweb.DataContracts;
using Lucasweb.Models;
using Lucasweb.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lucasweb.Controllers
{
    public class SharedController : Controller
    {
        private UserIdentityManager _appIdManager;

        private IdentityContext AUIdb = new IdentityContext();

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
                return (_userDataManager ?? ClassFactory.CreateClass<IUserManager>());
            }
        }


        [ActionName("_DropDownStuff")]
        public PartialViewResult _DropDownStuff()
        {
            AppUserId AUI = AppIdManager.FindById(User.Identity.GetUserId());
            if (AUI == null)
            {
                return PartialView();
            }
            else
            {
                User UserData = UserDataManager.GetUser(AUI.UserId);
                return PartialView(UserData);
            }

        }
    }
}
