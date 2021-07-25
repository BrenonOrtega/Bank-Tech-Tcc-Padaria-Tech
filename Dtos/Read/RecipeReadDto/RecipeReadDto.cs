using System.Collections.Generic;

namespace PadariaTech.Dtos.Read
{
    public class RecipeReadDto
    {
        public string Name { get; set; }

        public double Portion { get; set; }
        
        public ICollection<IngredientReadDto> Ingredients { get; set; }

        public ProductReadDto BakedProduct { get; set; }

        public RecipeReadDto()
        {
            Ingredients = new HashSet<IngredientReadDto>();
        }
    }
}