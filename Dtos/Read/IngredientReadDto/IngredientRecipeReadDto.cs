namespace PadariaTech.Dtos.Read
{
    public class IngredientRecipeReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Portion { get; set; }

        public RecipeProductReadDto Product { get; set; }
    }
}