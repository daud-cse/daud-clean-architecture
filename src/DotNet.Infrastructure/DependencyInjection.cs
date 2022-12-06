using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DotNet.ApplicationCore.Interfaces.User;
using DotNet.Infrastructure.Persistence.Contexts;
using DotNet.Infrastructure.Persistence.Repositories.User;
using System.Diagnostics.CodeAnalysis;

namespace DotNet.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection

    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DotNetContext>(options =>
               options.UseSqlServer(defaultConnectionString));
            services.AddScoped<DbContext, DotNetContext>();
            // services.AddScoped<IProductRepository, ProductRepository>();            
           
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var serviceProvider = services.BuildServiceProvider();
            try
            {
                var dbContext = serviceProvider.GetRequiredService<DotNetContext>();
                dbContext.Database.Migrate();
            }
            catch
            {
            }

            return services;
        }
    }
}