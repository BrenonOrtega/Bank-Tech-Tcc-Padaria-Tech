using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PadariaTech.Models.Base;

namespace PadariaTech.Models
{
    public class Ingredient : EntityBase
    {
        [Range(0, 999)]
        public double Quantity { get; set; }

        [MaxLength(35)]
        public string Measurement { get; set; }

        public int IdProduct;

        [ForeignKey(nameof(IdProduct))]
        public Product Product { get; set;}

        public int RecipeId;
        public Recipe Recipe{ get; set; }
    }
}
