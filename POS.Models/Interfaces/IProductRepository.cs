
using System.Collections;
using System.Collections.Generic;

namespace POS.Models.Interfaces
{
    public interface IProductRepository:ICommonRepository<Product>
    {
       ICollection<Product>  GetProductsWithCategory();
    }
}
