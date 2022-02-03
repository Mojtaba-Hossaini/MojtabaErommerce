using System.Text.Json;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace InfraStructure.Data;
public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.ProductBrands.Any())
            {
                var brandDate = File.ReadAllText("../InfraStructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandDate);
                foreach (var item in brands)
                {
                    context.ProductBrands.Add(item);
                }
                await context.SaveChangesAsync();
            }

            if (!context.ProductTypes.Any())
            {
                var typeDate = File.ReadAllText("../InfraStructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typeDate);
                foreach (var item in types)
                {
                    context.ProductTypes.Add(item);
                }
                await context.SaveChangesAsync();
            }

            if (!context.Products.Any())
            {
                var productDate = File.ReadAllText("../InfraStructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productDate);
                foreach (var item in products)
                {
                    context.Products.Add(item);
                }
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<StoreContextSeed>();
            logger.LogError(ex.Message);
        }

    }
}
