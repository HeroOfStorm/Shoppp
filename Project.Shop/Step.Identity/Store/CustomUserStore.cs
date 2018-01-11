using Microsoft.AspNet.Identity.EntityFramework;
using Step.Identity.Model;
using System.Data.Entity;

namespace Step.Identity.Store
{
    public class CustomUserStore : UserStore<AppUser, AppRole, int,
       CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        //CustomUserStore(DbContext context)
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
