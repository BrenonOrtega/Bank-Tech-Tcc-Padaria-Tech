using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PadariaTech.Models.Base;

namespace PadariaTech.Models
{
    public class Recipe : EntityBase
    {
        public ICollection<Ingredient> Ingredients { get; set; }

        public int IdBakedProduct;

        [ForeignKey(nameof(IdBakedProduct))]
        public BakedProduct BakedProduct { get; set; }
    }
}