using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Step.Identity.Manager;
using Step.Identity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Step.Identity.Store
{
    public class DbInitialize : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        private async Task SeedAsync(ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            {
                var store = new CustomRoleStore(context);
                var manager = new ApplicationRoleManager(store);
                var role = new AppRole { Name = "AppAdmin" };

                await manager.CreateAsync(role);
                var roleGreo = new AppRole { Name = "AppClient" };
                await manager.CreateAsync(roleGreo);
            }
            if (!context.Users.Any(u => u.UserName == "Sergeyk2000@gmail.com"))
            {
                var store = new CustomUserStore(context);
                var manager = new ApplicationUserManager(store);
                var user = new AppUser
                {
                    FirstName="Sergey", LastName="Admin",
                    UserName = "Sergeyk2000@gmail.com",
                    SubdivisionId = 0,
                    Email = "Sergeyk2000@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0123456789",
                    PhoneNumberConfirmed = true
                };
               

                await manager.CreateAsync(user, "15sevenNation");

            

                //Add User To Role
                await manager.AddToRoleAsync(user.Id, "AppAdmin");
                ////Add User Claims
                await manager.AddClaimAsync(user.Id, new Claim(ClaimTypes.GivenName, "A Person"));
                await manager.AddClaimAsync(user.Id, new Claim(ClaimTypes.Gender, "Man"));
                await manager.AddClaimAsync(user.Id, new Claim(ClaimTypes.DateOfBirth, "01.01.2001"));

               
            }
            if (!context.Users.Any(u => u.UserName == "Bot228@gmail.com"))
            {
                var store = new CustomUserStore(context);
                var manager = new ApplicationUserManager(store);
                var userGreo1 = new AppUser
                {
                    FirstName = "Bot228",
                    LastName = "Bot228",
                    UserName = "Bot228@gmail.com",
                    SubdivisionId = 1,
                    Email = "Bot228@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0123456789",
                    PhoneNumberConfirmed = true
                };


                await manager.CreateAsync(userGreo1, "Bot2281");
                //Add User To Role
                await manager.AddToRoleAsync(userGreo1.Id, "AppClient");
            }
            if (!context.Users.Any(u => u.UserName == "Bot220@gmail.com"))
            {
                var store = new CustomUserStore(context);
                var manager = new ApplicationUserManager(store);
                var userGreo2 = new AppUser
                {
                    FirstName = "Bot220",
                    LastName = "Bot220",
                    UserName = "Bot220@gmail.com",
                    SubdivisionId = 2,
                    Email = "Bot220@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0123456789",
                    PhoneNumberConfirmed = true
                };


                await manager.CreateAsync(userGreo2, "Bot2201");
                //Add User To Role
                await manager.AddToRoleAsync(userGreo2.Id, "AppClient");
            }


        }


        protected override void Seed(ApplicationDbContext context)
        {

            Task.Run(async () => { await SeedAsync(context); }).Wait();

            base.Seed(context);
        }
    }
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
       
        public ApplicationDbContext()
            : base()
        {
            if (!Database.Exists())
            {
                Database.SetInitializer<ApplicationDbContext>(new DbInitialize());
            }

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
