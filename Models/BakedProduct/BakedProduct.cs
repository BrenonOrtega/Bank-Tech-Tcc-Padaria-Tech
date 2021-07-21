using System.ComponentModel.DataAnnotations.Schema;

namespace PadariaTech.Models
{
    public class BakedProduct : Product
    {
        public int IdRecipe;
        
        [ForeignKey(nameof(IdRecipe))]
        public Recipe Recipe { get; set; }

    }
}