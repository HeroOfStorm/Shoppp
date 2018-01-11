using Fshop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Step.Identity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Fshop.Controllers
{
    public class AuthoriseController : Controller
    {

        private readonly UserManager<AppUser, int> userManager;

        public AuthoriseController()
            : this(Startup1.UserManagerFactory.Invoke())
        {
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Registr(string returnUrl)
        {

            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registr(LogInModel model)
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

        public AuthoriseController(UserManager<AppUser, int> userManager)
        {
            this.userManager = userManager;
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult LogIn(string returnUrl)
        {
            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = userManager.Find(model.Email, model.Password);
            var identity = userManager.CreateIdentity(
                         user, DefaultAuthenticationTypes.ApplicationCookie);

            GetAuthenticationManager().SignIn(identity);
            if (user != null){
                if( user.Email == "a@gmail.com")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Product");
                }
              
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            GetAuthenticationManager().SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Product");
        }
        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            //добавить сборку Microsoft.Owin.Host.SystemWeb - NuGet package, чтобы был доступен GetOwinContext()!!!

            return ctx.Authentication;
        }
    }
}