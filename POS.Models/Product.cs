using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Models
{
    public class Product
    {
        public long Id { set; get; }
        [Required]
        [StringLength(5)]
        public string Code { set; get; }
        [Required]
        public string Name { set; get; }
      
        public long CategoryId { set; get; }
        public virtual ProductCategory Category { set; get; }
        public virtual List<StockDetail> StockDetails { set; get; } 
    }
}