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
                    "Manage_Role_Selector",
                    "Manage/Roles/{action}/{User}/{Role}",
                    new { controller = "Roles", action = "Add", Role = UrlParameter.Optional }
                );

            context.MapRoute(
                    "Manage_Selection",
                    "Manage/{controller}/{F_index}-{L_index}",
                    new { action = "Index" }
                );

            context.MapRoute(
                "Manage_default",
                "Manage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}