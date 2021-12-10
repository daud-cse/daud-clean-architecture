using Microsoft.EntityFrameworkCore;
using Daud.ApplicationCore.Entities;

namespace Daud.Infrastructure.Persistence.Contexts
{
    public class DaudContext : DbContext
    {
        public DaudContext(DbContextOptions<DaudContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}