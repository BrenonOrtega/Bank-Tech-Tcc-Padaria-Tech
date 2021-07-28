namespace PadariaTech.Application.Dtos.Read
{
    public class IngredientReadDto
    {
        public int Id;

        public IngredientProductReadDto Product { get; set; }

        public double Quantity { get; set; }

        public string Measurement { get; set; }

        public IngredientRecipeReadDto Recipe { get; set; }
    }
}