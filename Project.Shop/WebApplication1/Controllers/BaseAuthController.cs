using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Step.Identity.Manager;
using Step.Identity.Model;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class BaseAuthController : Controller
    {

        protected AppUser CurrentUser
        {
            get
            {
                return UserManager.FindByName(HttpContext.User.Identity.Name);
            }
        }

        protected ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        protected bool IsUserGreo
        {
            get
            {
                return UserManager.IsInRole(CurrentUser.Id, "AppGreo");
            }
        }
    }
}