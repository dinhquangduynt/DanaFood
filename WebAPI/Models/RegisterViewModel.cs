using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class RegisterViewModel
    {
        public string FullName { set; get; }

        public string Password { set; get; }

        public string ConfirmPassword { set; get; }

        public string Email { set; get; }

        public string Address { set; get; }

        public string PhoneNumber { set; get; }

        public DateTime BirthDay { set; get; }
    }
}