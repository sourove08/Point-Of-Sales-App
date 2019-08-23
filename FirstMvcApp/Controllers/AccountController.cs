using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using POS.Models.Database;
using POS.Models.IdentityModels;
using POS.Models.ViewModels;

namespace FirstMvcApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
       static PosDbContext context=new PosDbContext();
       private ApplicationSignInManager signInManager;
       private ApplicationUserManager   userManager;
        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRole(CreateRoleViewModel model)
        {
            var role = new ApplicationRole()
            {
                Name = model.Name
            };
            var roleManager = HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            roleManager.Create(role);
            return Content("Role Created sucessfully");
        }
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
       
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(ApplicationUserViewModel model)
        {
            
            var user = new ApplicationUser()
            {
                UserName = model.UserName,
               
            };
            signInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            //var context = new PosDbContext();
            //var userStore = new UserStore<ApplicationUser>(context);
            //var userManager = new UserManager<ApplicationUser>(userStore);
            //var existingUser = userManager.FindByName(user.UserName);
            //var authenticationManager = HttpContext.GetOwinContext().Authentication;
           // var signinManager = new SignInManager<ApplicationUser,string>(userManager,authenticationManager);
          var status=await signInManager.PasswordSignInAsync(user.UserName, model.Password, true, true);
          switch (status)
          {
              case SignInStatus.Success:
                  return RedirectToAction("Index","Home");
             
              case SignInStatus.Failure:
              default:
                  ModelState.AddModelError("", "Invalid login attempt!! Please Correctly give User Name & Password");
                  return View(model);
          }
           
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
           // RegisterUserViewModel model=new RegisterUserViewModel();
            ViewBag.roleId= new SelectList(context.Roles.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterUserViewModel model)
        {
            bool a = ModelState.IsValid;
            var user = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                Location = model.Location,
                //Id =Guid.NewGuid().ToString()

            };
             userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //create a new user
           
            //string roleName = role.Name;
            //string userId = user.Id;

            var result = await userManager.CreateAsync(user, model.Password);
            

            if (result.Succeeded)
            {
                string id = model.RoleId;
                var role = context.Roles.ToList().Find(m => m.Id == id);
                userManager.AddToRole(user.Id, role.Name); 
                return Content("You are Register Sucessfully Please LogIn!!!");
            }
            AddErrors(result);
            ViewBag.roleId = new SelectList(context.Roles.ToList(), "Id", "Name");
            //return Content("You are not Register sucessfully");
            return View(model);
        }

        [HttpGet]
        //[AllowAnonymous]
      //  [ValidateAntiForgeryToken]
     

        [Authorize(Roles = "Admin")]

        public ActionResult GetData()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Content("User Name: " + User.Identity.Name);
            }
            else
            {
                return Content("User is not loged in!");
            }
        }

        public ActionResult GetDataOne()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Content("User Name: " + User.Identity.Name);
            }
            else
            {
                return Content("User is not loged in!");
            }
        }
        //[AllowAnonymous]
        public ActionResult LogOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Content("User is sign Out");
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (userManager != null)
                {
                    userManager.Dispose();
                    userManager = null;
                }

                if (signInManager != null)
                {
                    signInManager.Dispose();
                    signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

	}
}