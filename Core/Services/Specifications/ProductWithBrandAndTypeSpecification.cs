using System.Linq.Expressions;
using Domain.Entities.ProductModule;

namespace Services.Specifications;

public class ProductWithBrandAndTypeSpecification : BaseSpecifications<Product, int>
{
    // Get All Products with brand and type
    public ProductWithBrandAndTypeSpecification(int? typeId, int? brandId)
        : base(p => (!typeId.HasValue || p.TypeId == typeId)
                    && (!brandId.HasValue || p.BrandId == brandId))
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