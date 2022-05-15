using Microsoft.EntityFrameworkCore;
using DotNet.ApplicationCore.Entities;

namespace DotNet.Infrastructure.Persistence.Contexts
{
    public class DaudContext : DbContext
    {
        public DaudContext(DbContextOptions<DaudContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}