using System.ComponentModel.DataAnnotations.Schema;

namespace PadariaTech.Domain.Models
{
    public class BakedProduct : Product
    {
        public Recipe Recipe { get; set; }
    }
}