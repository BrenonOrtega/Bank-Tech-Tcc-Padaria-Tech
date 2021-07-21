using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PadariaTech.Data;
using PadariaTech.Models;
using PadariaTech.Repository;

namespace PadariaTech.Extensions
{
    public static class AppSetup
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BakeryContext>(options => options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBakedProductRepository, BakedProductRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
