using POS.Models;
using POS.Models.Database;
using POS.Models.Interfaces;

namespace POS.DAL
{
    public class ProductCategoryRepository:CommonRepository<ProductCategory>,IProductCategoryRepository
    {
        public ProductCategoryRepository():base(new PosDbContext())
        {
            
        }
    }
}