using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PadariaTech.Domain.Models;

namespace PadariaTech.Domain.Models
{
    public class Ingredient : EntityBase
    {
        [Range(0, 999)]
        public double Quantity { get; set; }

        [MaxLength(35)]
        public string Measurement { get; set; }

        public int ProductId;

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set;}

        public int RecipeId;
        public Recipe Recipe{ get; set; }

        internal void UseQuantity()
        {
            Product.RemoveQuantity(Quantity);
        }
    }
}
