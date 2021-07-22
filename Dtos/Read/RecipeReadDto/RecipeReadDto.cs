using System.Collections.Generic;

namespace PadariaTech.Dtos.Read
{
    public class RecipeReadDto
    {
        public string Name { get; set; }

        public double Portion { get; set; }

        ICollection<IngredientReadDto> Ingredients { get; set; }

        public RecipeReadDto()
        {
            Ingredients = new HashSet<IngredientReadDto>();
        }
    }
}