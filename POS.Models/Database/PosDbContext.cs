using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using POS.Models.IdentityModels;


namespace POS.Models.Database
{
  
    public class PosDbContext:IdentityDbContext<ApplicationUser>
    {
        public PosDbContext(): base("PosDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public static PosDbContext Create()
        {
            return new PosDbContext();
        }
       public  DbSet<Customer> Customers { set; get; }
       public  DbSet<Product> Products { set; get; }
       public  DbSet<ProductCategory> ProductCategories { set; get; }
       public DbSet<StockHeader> StockHeaders { set; get; } 
       public System.Data.Entity.DbSet<POS.Models.StockDetail> StockDetails { get; set; }
          
       
    }
}