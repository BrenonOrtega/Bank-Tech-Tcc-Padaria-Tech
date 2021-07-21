using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PadariaTech.Models.Base;

namespace PadariaTech.Models
{
    public partial class Product : EntityBase
    {
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        [MaxLength(30)]
        public string Measure { get; set; } 


        public override string ToString() => 
            $"Product { Id } - { Name } - { Price } - { StockQuantity } { Measure }";
    }
}
