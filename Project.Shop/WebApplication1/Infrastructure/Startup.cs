using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(IdentityExample.Infrastructure.Startup))]

namespace IdentityExample.Infrastructure
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //добавляем модуль аутентификации на основе cookie файлов
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                //здесь указывается маршрут, по которому направляется неавторизованный пользователь
                LoginPath = new PathString("/auth/login")
            });
        }
    }
}
