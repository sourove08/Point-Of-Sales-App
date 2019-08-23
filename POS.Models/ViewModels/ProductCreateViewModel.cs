using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace POS.Models.ViewModels
{
  public class ProductCreateViewModel
    {
        public long Id { set; get; }
        [Required]
        [StringLength(5)]
        public string Code { set; get; }
        [Required]
        public string Name { set; get; }
        [Display(Name = "Category")]
        public long CategoryId { set; get; }
       // public  ProductCategory Category { set; get; }
        public ICollection<Product> Products { set; get; }
        public SelectList ProductCategoryLookUp { set; get; }
    }
}
