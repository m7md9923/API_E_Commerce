using System.Linq.Expressions;
using Domain.Entities.ProductModule;

namespace Services.Specifications;

public class ProductWithBrandAndTypeSpecification : BaseSpecifications<Product, int>
{
    // Get all products with brand and type
    public ProductWithBrandAndTypeSpecification() : base(null)
    {
        AddIncludes(p => p.productBrand);
        AddIncludes(p => p.productType);
    }
    
    // Get Product By Id ==> Includes Type and Brand
    public ProductWithBrandAndTypeSpecification(int id) : base(p => p.Id == id)
    {
        AddIncludes(p => p.productBrand);
        AddIncludes(p => p.productType);
    }
}