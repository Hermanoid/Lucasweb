using Lucasweb.DataContracts;
using Lucasweb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.Controllers
{
    public class UserIdentityManager : UserManager<AppUserId>
    {
        public UserIdentityManager(IUserStore<AppUserId> store)
        : base(store)
        {
        }

        public static UserIdentityManager Create(
        IdentityFactoryOptions<UserIdentityManager> options, IOwinContext context)
        {
            var manager = new UserIdentityManager(
                new UserStore<AppUserId>(context.Get<IdentityContext>()));

            // optionally configure your manager
            // ...

            return manager;
        }
    }
}
