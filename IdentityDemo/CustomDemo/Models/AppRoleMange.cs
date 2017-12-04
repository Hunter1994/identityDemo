using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomDemo.Models
{
    public class AppRoleMange : RoleManager<IdentityRole>
    {
        public AppRoleMange(IRoleStore<IdentityRole, string> store) : base(store)
        {
        }

        public static AppRoleMange Create(IdentityFactoryOptions<AppRoleMange> options, IOwinContext context)
        {
            return new AppRoleMange(new RoleStore<IdentityRole>(context.Get<CustomDemoDbContext>()));
        }
    }
}