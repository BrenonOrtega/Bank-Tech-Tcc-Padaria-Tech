using System.ComponentModel.DataAnnotations.Schema;

namespace PadariaTech.Domain.Models
{
    public class BakedProduct : Product
    {
        public int RecipeId { get; set; }

        [ForeignKey(nameof(RecipeId))]
        public Recipe Recipe { get; set; }
    }
}