using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Daud.ApplicationCore.Interfaces;
using Daud.ApplicationCore.Interfaces.Security;
using Daud.ApplicationCore.Interfaces.Users;
using Daud.Infrastructure.Persistence.Contexts;
using Daud.Infrastructure.Persistence.Repositories;
using Daud.Infrastructure.Persistence.Repositories.Security;
using Daud.Infrastructure.Persistence.Repositories.Users;
using System.Diagnostics.CodeAnalysis;

namespace Daud.Infrastructure
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