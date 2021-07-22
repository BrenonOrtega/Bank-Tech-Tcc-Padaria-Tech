using System.ComponentModel.DataAnnotations;

namespace PadariaTech.Dtos.Create
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
        public int IdProduct { get; set; }

        [Required]
        public int IdRecipe { get; set; }
    }

}