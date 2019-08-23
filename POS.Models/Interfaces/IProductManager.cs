using System.Collections.Generic;

namespace POS.Models.Interfaces
{
   public interface IProductManager:ICommonManager<Product>
    {
       ICollection<Product> GetProductsByCategory(long categoryId);
    }
}
