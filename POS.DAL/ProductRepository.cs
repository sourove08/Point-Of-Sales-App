using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using POS.Models;
using POS.Models.Database;
using POS.Models.Interfaces;

namespace POS.DAL
{
    public class ProductRepository:CommonRepository<Product>,IProductRepository
    {
        
        public ProductRepository() : base(new PosDbContext())
        {
            
        }

        private PosDbContext PosDbContext
        {
            get { return ((PosDbContext) db); }
        }

        public ICollection<Product> GetProductsWithCategory()
        {
            return PosDbContext.Products.Include(p => p.Category).ToList(); 
        }
    }
}