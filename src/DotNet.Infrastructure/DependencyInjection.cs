using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DotNet.ApplicationCore.Interfaces;
using DotNet.ApplicationCore.Interfaces.Security;
using DotNet.ApplicationCore.Interfaces.Users;
using DotNet.Infrastructure.Persistence.Contexts;
using DotNet.Infrastructure.Persistence.Repositories;
using DotNet.Infrastructure.Persistence.Repositories.Security;
using DotNet.Infrastructure.Persistence.Repositories.Users;
using System.Diagnostics.CodeAnalysis;

namespace DotNet.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DaudContext>(options =>
               options.UseSqlServer(defaultConnectionString));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddSingleton<ITokenService, TokenService>();
            services.AddSingleton<IUserRepository,UserRepository>();
            

            var serviceProvider = services.BuildServiceProvider();
            try
            {
                var dbContext = serviceProvider.GetRequiredService<DaudContext>();
                dbContext.Database.Migrate();
            }
            catch
            {
            }

            return services;
        }
    }
}