using System.Collections.Generic;

namespace POS.Models
{
    public class ProductCategory
    {
        public long Id { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public List<Product> Products { set; get; } 
    }
}