using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class LoginViewModel
    {
       
        public string Username { get; set; }

        public string Password { get; set; }

        //public Boolean rememberMe { get; set; }
    }
}