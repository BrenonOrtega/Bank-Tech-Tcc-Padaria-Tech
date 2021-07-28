using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PadariaTech.Domain.Models;

namespace PadariaTech.Domain.Models
{
    public class Recipe : EntityBase
    {
        public double Portion { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }

        public BakedProduct BakedProduct { get; set; }

        public Recipe()
        {
            Ingredients = new HashSet<Ingredient>();
        }
    }
}
