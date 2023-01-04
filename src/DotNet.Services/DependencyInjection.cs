using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DotNet.Infrastructure.Persistence.Contexts;
using System.Diagnostics.CodeAnalysis;
using DotNet.Services.Repositories.Interfaces;
using System.Runtime.CompilerServices;
using DotNet.Services.Repositories.Common;
using DotNet.Services.Repositories.Infrastructure;
using DotNet.Services.Repositories;
using DotNet.Services.Services.Interfaces;
using DotNet.Services.Services.Infrastructure;
using DotNet.Services.Repositories.Interfaces.Common;
using DotNet.Services.Services.Interfaces.Common;
using DotNet.Services.Services.Common;
using DotNet.Services.Services;

namespace DotNet.Services
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DotNetContext>(options => options.UseSqlServer(defaultConnectionString));
            services.AddScoped<DbContext, DotNetContext>();

            DependencyInjection.AddRepositories(services);
            DependencyInjection.AddServices(services);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
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

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}