using System.Reflection;
using System.Reflection.Metadata;
using Persistence;

namespace Persistence.Data;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // use reflection 

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
        // Configs apply ==> Persistence [AssemblyReference]
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
    
}