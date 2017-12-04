using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomDemo.Models
{
    public class RegisterModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPasswod { get; set; }
    }
}