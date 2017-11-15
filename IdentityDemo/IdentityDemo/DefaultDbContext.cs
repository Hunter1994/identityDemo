using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using IdentityDemo.Models;

namespace IdentityDemo
{
    public class DefaultDbContext:IdentityDbContext
    {
        public virtual IDbSet<Product> Products { get; set; }
        public DefaultDbContext() : base("Default")
        { }
    }
}