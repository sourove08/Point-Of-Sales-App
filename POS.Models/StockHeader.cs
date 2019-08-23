using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Models
{
    public class StockHeader
    {
        public long Id { set; get; }
        public string BatchNo { set; get; }
        [DataType(DataType.Date)]
        [Display(Name = "Stock Date")]
        [Column(TypeName = "DateTime2")]
        public DateTime StockDate { set; get; }
        public ICollection<StockDetail> StockDetails { set; get; }

    }
}