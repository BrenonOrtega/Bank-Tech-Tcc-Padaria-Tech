using Microsoft.EntityFrameworkCore;
using PadariaTech.Models;

namespace PadariaTech.Data
{
    public class BakeryContext : DbContext
    {
        public BakeryContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(5,2)");
        }

        DbSet<Ingredient> Ingredients { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<Recipe> Recipes { get; set; }

        DbSet<BakedProduct> BakedProducts { get; set; }
    }
}
