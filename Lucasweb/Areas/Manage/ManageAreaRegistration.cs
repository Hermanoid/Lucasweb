using System.Web.Mvc;

namespace Lucasweb.Areas.Manage
{
    public class ManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Manage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Manage_User_Empty",
                url: "Manage/Users",
                defaults: new { controller = "Users", action = "Index", F_index = 0, L_index = 50 }
                );

            context.MapRoute(
                    "Manage_Role_Selector",
                    "Manage/Roles/{action}/{User}/{Role}",
                    new { controller = "Roles", action = "Add", Role = UrlParameter.Optional }
                );

            context.MapRoute(
                    "Manage_Selection",
                    "Manage/{controller}/{F_index}-{L_index}",
                    new { action = "Index" }
                );

            //context.MapRoute(
            //    "Manage_Home",
            //    "Manage/Home/{action}",
            //    new { controller = "Home", action = "Index" },

            //    );

            context.MapRoute(
                "Manage_default",
                "Manage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "Lucasweb.Areas.Manage.Controllers" }
            );
        }
    }
}