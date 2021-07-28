using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PadariaTech.Data;
using PadariaTech.Domain.Models;
using PadariaTech.Data.Repository;
using PadariaTech.Application.Services;
using System;

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
            services.AddScoped<RecipeService>();
            services.AddTransient<ProductService>();
            services.AddTransient<BakedProductService>();
            services.AddTransient<IngredientService>();
            
            return services;
        }

        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(assemblies: AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
