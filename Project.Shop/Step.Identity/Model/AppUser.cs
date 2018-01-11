using Microsoft.AspNet.Identity.EntityFramework;
using System;


namespace Step.Identity.Model
{
    public class AppUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SubdivisionId { get; set; }
        //public DateTime DateBirthday { get; set; }
    }
    public class CustomUserRole : IdentityUserRole<int>
    {
    }
    public class CustomUserClaim : IdentityUserClaim<int> { }
    public class CustomUserLogin : IdentityUserLogin<int> { }
}
