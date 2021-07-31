using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using PadariaTech.Domain.Models;

namespace PadariaTech.Domain.Models
{
    public class Recipe : EntityBase
    {
        [MaxLength(150)]
        public string Name { get; set; }

        public double Portion { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }

        public BakedProduct BakedProduct { get; set; }

        public Recipe()
        {
            Ingredients = new HashSet<Ingredient>();
        }

        public bool UseIngredients()
        {
            if(CanBake())
            {
                foreach(var ingredient in Ingredients)
                    ingredient.UseQuantity();
                return true;
            }
            return false;
        }

        public bool CanBake()
        {
            if(Ingredients.Count > 0 && Ingredients.All(i => i.Quantity <= i.Product.StockQuantity))
                return true;
            
            return false;
        }
    }
}
