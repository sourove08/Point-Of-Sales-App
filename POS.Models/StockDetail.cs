using System.ComponentModel.DataAnnotations;

namespace POS.Models
{
    public class StockDetail
    {
        public long Id { set; get; }
        public StockHeader StockHeader { set; get; }
        public long StockHeaderId { set; get; }
        [Required(ErrorMessage = "Please enter the quantity")]
        public double Quantity { set; get; }
        [Display(Name ="Product")]
        public long ProductId { set; get; }
        public Product Product { set; get; }

    }
}