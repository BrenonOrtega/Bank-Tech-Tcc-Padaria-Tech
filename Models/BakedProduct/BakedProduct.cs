using System.ComponentModel.DataAnnotations.Schema;

namespace PadariaTech.Models
{
    public class BakedProduct : Product
    {
        public Recipe Recipe { get; set; }
    }
}