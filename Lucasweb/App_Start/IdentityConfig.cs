using Lucasweb.Controllers;
using Lucasweb.DataContracts;
using Lucasweb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new IdentityContext());
            app.CreatePerOwinContext<UserIdentityManager>(UserIdentityManager.Create);
            app.CreatePerOwinContext<RoleManager<UserRole>>((options, context) =>
                new RoleManager<UserRole>(
                    new RoleStore<UserRole>(new IdentityContext())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Login"),
            });
        }
    }
}
