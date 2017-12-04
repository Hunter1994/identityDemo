using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CustomDemo.Models
{
    public class CustomDemoDbContext:IdentityDbContext
    {
        public CustomDemoDbContext() : base("Default") { }

        public static CustomDemoDbContext Create()
        {
            return new CustomDemoDbContext();
        }
    }
}