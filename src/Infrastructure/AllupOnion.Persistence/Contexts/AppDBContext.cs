

using AllupOnion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AllupOnion.Persistence.Contexts
{
     public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options) { }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColors> ProductColors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  
            base.OnModelCreating(modelBuilder);
        }
    }
}
