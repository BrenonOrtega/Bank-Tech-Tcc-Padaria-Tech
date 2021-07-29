using System.ComponentModel.DataAnnotations;

namespace PadariaTech.Application.Dtos.Create
{
    public class IngredientCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required, Range(0, double.PositiveInfinity)]
        public double Quantity { get; set; }

        [Required]
        public string Measurement { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int RecipeId { get; set; }
    }

}