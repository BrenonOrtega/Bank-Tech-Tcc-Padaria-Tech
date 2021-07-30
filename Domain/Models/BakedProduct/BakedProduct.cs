using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PadariaTech.Domain.Models
{
    public class BakedProduct : Product
    {
        public int RecipeId { get; set; }

        [Required]
        [ForeignKey(nameof(RecipeId))]
        public Recipe Recipe { get; set; }

        public void Bake()
        {
            if(Recipe.UseIngredients())
            {
                AddQuantity(Recipe.Portion);
            }
            else 
            {
                throw InvalidOperationException("One or more ingredients have not enough stock");
            }

        }

        private Exception InvalidOperationException(string v)
        {
            throw new NotImplementedException();
        }
    }
}
