using System;
using PadariaTech.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PadariaTech.Dtos.Create
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required, Range(0, double.PositiveInfinity)]
        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        [Required]
        public string Measure { get; set; }

        [Required]
        public ProductTypes ProductType { get; set; }
    }
}
