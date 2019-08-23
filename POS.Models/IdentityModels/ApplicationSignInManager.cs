using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace POS.Models.IdentityModels
{
   public class ApplicationSignInManager:SignInManager<ApplicationUser,string>
   {
       public ApplicationSignInManager(UserManager<ApplicationUser, string> userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
       {
       }


       public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
       {
           return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
       }
   }
}
