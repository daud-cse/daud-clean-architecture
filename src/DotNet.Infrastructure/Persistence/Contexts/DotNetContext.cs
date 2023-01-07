using Microsoft.EntityFrameworkCore;
using DotNet.ApplicationCore.Entities;

namespace DotNet.Infrastructure.Persistence.Contexts
{
    public class DotNetContext : DbContext
    {
        public DotNetContext(DbContextOptions<DotNetContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}