using System.ComponentModel.DataAnnotations;

namespace PadariaTech.Application.Dtos.Create
{
    public class BakedProductCreateDto : ProductCreateDto
    {
        [Required]
        public int RecipeId { get; set; }

    }
}