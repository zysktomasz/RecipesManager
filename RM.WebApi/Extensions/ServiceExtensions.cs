using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RM.Repo;
using RM.Service.Interfaces;
using RM.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RM.WebApi.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureRecipeManagerServices(this IServiceCollection services)
        {
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IIngredientService, IngredientService>();
        }
    }
}
