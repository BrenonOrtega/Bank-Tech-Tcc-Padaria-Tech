using Microsoft.EntityFrameworkCore;
using PadariaTech.Domain.Enum;
using PadariaTech.Domain.Models;
namespace PadariaTech.Data
{
    public class BakeryContext : DbContext
    {
        public BakeryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(5,2)");

            builder.Entity<Product>()
                .Property(p => p.Type)
                .HasConversion(
                    type => type.ToString(),
                    type => (ProductTypes)System.Enum.Parse(typeof(ProductTypes), type));
        }

        DbSet<Ingredient> Ingredients { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<Recipe> Recipes { get; set; }

        DbSet<BakedProduct> BakedProducts { get; set; }
    }
}
