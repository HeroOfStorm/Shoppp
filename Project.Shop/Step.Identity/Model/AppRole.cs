using Microsoft.AspNet.Identity.EntityFramework;

namespace Step.Identity.Model
{
    public class AppRole : IdentityRole<int, CustomUserRole>
    {
        public AppRole() { }
        public AppRole(string name) { Name = name; }
    }
}
