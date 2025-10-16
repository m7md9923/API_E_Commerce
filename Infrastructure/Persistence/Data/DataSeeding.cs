using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Contracts;
namespace Persistence.Data;

public class DataSeeding (StoreDbContext _dbContext) : IDataSeeding
{
    public async Task SeedDataAsync()
    {
        try
        {
            // Any pending migration ==> apply DB
            if ((await _dbContext.Database.GetPendingMigrationsAsync()).Any())
            {
                // Applies any pending migrations for the context to the DB
                // Will Create the DB if it does not already exist 
                await _dbContext.Database.MigrateAsync();   
            }

            if (!_dbContext.ProductBrands.Any())
            {
                var productBrandData = File.OpenRead("../Infrastructure/Persistence/Data/DataSeed/brands.json");
                // json ==> C# object [List<ProductBrand>]
                var productBrands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(productBrandData);

                if (productBrands is not null && productBrands.Any())
                {
                    await _dbContext.ProductBrands.AddRangeAsync(productBrands);
                }
            }

            if (!_dbContext.ProductTypes.Any())
            {
                var productTypeData = File.OpenRead("../Infrastructure/Persistence/Data/DataSeed/types.json");
                // json ==> C# object [List<ProductType>]
                var productTypes = await JsonSerializer.DeserializeAsync<List<ProductType>>(productTypeData);
                if (productTypes is not null && productTypes.Any())
                {
                    await _dbContext.ProductTypes.AddRangeAsync(productTypes);
                }
            }

            if (!_dbContext.Products.Any())
            {
                var productData = File.OpenRead("../Infrastructure/Persistence/Data/DataSeed/products.json");
                // json ==> C# object [List<Product>]
                var products = await JsonSerializer.DeserializeAsync<List<Product>>(productData);
                if (products is not null && products.Any())
                {
                    await _dbContext.Products.AddRangeAsync(products);
                }
            }
        
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            // Handle Exception
        }

    }

    public Task SeedData()
    {
        throw new NotImplementedException();
    }
}