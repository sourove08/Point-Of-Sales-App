using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using POS.Models.IdentityModels;

namespace POS.Models.ViewModels
{
   public class RegisterUserViewModel
    {
       [Required]
        public string UserName { set; get; }
       [Required]
        public string Password { set; get; }
       [Required]
        public string Email { set; get; }
       [Required]
        public string Location { set; get; }
        public string RoleId { set; get; } 
    }
}
