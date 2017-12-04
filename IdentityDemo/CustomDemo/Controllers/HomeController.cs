using CustomDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Security.Claims;

namespace CustomDemo.Controllers
{
    public class HomeController : Controller
    {
        private AppUserManager UserManager { get {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            } }
      
        private IAuthenticationManager AuthManager { get {
                return HttpContext.GetOwinContext().Authentication;
            } }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                ViewBag.Claims = identity.Claims;
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new CustomDemoDbContext()));
            var user = new IdentityUser() { UserName = model.UserName, Email = model.UserName };
            var result = userManager.Create(user, model.Password);
            if (result.Succeeded)
            {
                ClaimsIdentity claims = UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie).Result;
                AuthManager.SignOut();
                AuthManager.SignIn(new AuthenticationProperties()
                {
                    IsPersistent = false
                }, claims);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Login(RegisterModel model)
        {
            try
            {
                var user = await UserManager.FindAsync(model.UserName, model.Password);

                if (user == null) ModelState.AddModelError("", "Invalid name or password.");
                else {
                    ClaimsIdentity claims = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties()
                    {
                        IsPersistent = false
                    }, claims);
                }
                // var result = HttpContext.GetOwinContext().Get<SignInManager<IdentityUser, string>>().PasswordSignIn(model.UserName, model.Password, false, false);
            }
            catch (Exception e)
            {

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Out()
        {
            AuthManager.SignOut();
            return RedirectToAction("Index");
        }

    }
}