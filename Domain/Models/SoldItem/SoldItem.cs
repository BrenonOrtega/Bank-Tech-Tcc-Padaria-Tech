using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PadariaTech.Domain.Models
{
    public class SoldItem : EntityBase
    {
        public double Quantity { get; set; }

        public decimal Value { get => Product.Price * Convert.ToDecimal(Quantity); }

        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public int SellId { get; set; }
        [ForeignKey(nameof(SellId))]
        public Sell Sell { get; set; }
    }
}
