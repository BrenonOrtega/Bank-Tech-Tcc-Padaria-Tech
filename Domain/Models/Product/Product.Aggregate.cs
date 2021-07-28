namespace PadariaTech.Domain.Models
{
    public partial class Product
    {
        public Ingredient Ingredient { get; set; }

        public Recipe Recipe { get; set; }
    }
}