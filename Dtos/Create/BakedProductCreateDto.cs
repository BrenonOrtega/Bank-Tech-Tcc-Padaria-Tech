using System.ComponentModel.DataAnnotations;

namespace PadariaTech.Dtos.Create
{
    public class BakedProductCreateDto : ProductCreateDto
    {
        [Required]
        public int IdRecipe { get; set; }

    }
}