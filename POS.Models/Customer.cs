using System.ComponentModel.DataAnnotations;

namespace POS.Models
{
    public class Customer
    {
        public int id { set; get; }
        [Required]
       public string Name { set; get; }
        [Required]
      public string Email { set; get; }
    
        
       public string Address { set; get; }
    }
}