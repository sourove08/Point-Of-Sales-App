using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using POS.Models.Database;

namespace POS.Models.IdentityModels
{
   public class ApplicationRoleManager:RoleManager<ApplicationRole,string>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store) : base(store)
        {
        }


       public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
       {
           var manager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context.Get<PosDbContext>()));
           return manager;
       }

        
    }
}
