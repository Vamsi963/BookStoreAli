using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStoreAli.Models
{
    public class RegisterUser : User
    {
        [Required,Compare("Password",ErrorMessage ="Passwords doesnt match . Try Again")]
        public string ConfirmPassword { get; set; }
        public bool Remember { get; set; }
    }
}