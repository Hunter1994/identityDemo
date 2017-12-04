using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using CustomDemo.Models;

[assembly: OwinStartup(typeof(CustomDemo.Startup))]

namespace CustomDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.CreatePerOwinContext<CustomDemoDbContext>(CustomDemoDbContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.CreatePerOwinContext<AppRoleMange>(AppRoleMange.Create);


            // 使应用程序可以使用 Cookie 来存储已登录用户的信息
            // 并使用 Cookie 来临时存储有关使用第三方登录提供程序登录的用户的信息
            // 配置登录 Cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                CookieSecure=CookieSecureOption.Never
            });
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
