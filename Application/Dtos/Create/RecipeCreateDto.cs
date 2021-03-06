using System.ComponentModel.DataAnnotations;

namespace PadariaTech.Application.Dtos.Create
{
    public class RecipeCreateDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public double Portion { get; set; }
    }

}