using Lemon.BackgroundTask.Domain.Repositories;
using Lemon.BackgroundTask.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.BackgroundTask.EntityFrameworkCore
{
    public static class EntityFrameworkCoreModule
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            return services.AddDbContext();
        }
        
        private static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            IConfiguration configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            services.AddDbContextFactory<EfDbContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("Default")
                );
            });

            services.AddScoped<IDbContextProvider<EfDbContext>, DbContextProvider<EfDbContext>>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            return services;
        }
    }
}