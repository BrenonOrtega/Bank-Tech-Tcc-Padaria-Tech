using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

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

        [IgnoreDataMember]
        public int RecipeId { get; set; }
    }

}