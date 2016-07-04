using Microsoft.AspNet.Identity.EntityFramework;

namespace Lucasweb.DataContracts
{
    public class AppUserId : IdentityUser
    {
        public int UserId { get; set; }

    }
}
