using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Step.Identity.Model;
using Step.Identity.Store;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly UserManager<AppUser, int> userManager;

        static ApplicationDbContext context = new ApplicationDbContext();

        public RegistrationController()
            : this(Startup.UserManagerFactory.Invoke())
        {
        }

        public RegistrationController(UserManager<AppUser, int> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Registration(string returnUrl)
        {
            var model = new RegistrationModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var rees = userManager.Create(new AppUser { Email = model.Email, UserName = model.Email }, model.Password);
            
            return RedirectToAction("Login", "Authorise");
            var user = userManager.Find(model.Email, model.Password);

            if (user != null)
            {
                var identity = userManager.CreateIdentity(
                    user, DefaultAuthenticationTypes.ApplicationCookie);

                GetAuthenticationManager().SignIn(identity);
                return RedirectToAction("Login", "Authorise");
            }

            ModelState.AddModelError("", "Invalid email or password");
            return View(model);
        }
        private void SignIn(AppUser user)
        {
            var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.FirstName));
            identity.AddClaim(new Claim(ClaimTypes.Surname, user.LastName));

            GetAuthenticationManager().SignIn(identity);
        }
        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            return ctx.Authentication;
        }
    }
}