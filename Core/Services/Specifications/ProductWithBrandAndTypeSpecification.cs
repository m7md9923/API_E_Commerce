using System.Linq.Expressions;
using Domain.Entities.ProductModule;
using Shared.Enums;
using Shared.Specifications;

namespace Services.Specifications;

public class ProductWithBrandAndTypeSpecification : BaseSpecifications<Product, int>
{
    // Get All Products with brand and type
    public ProductWithBrandAndTypeSpecification(ProductSpecificationParameters parameters)
        : base(p => (!parameters.TypeId.HasValue || p.TypeId == parameters.TypeId)
                    && (!parameters.BrandId.HasValue || p.BrandId == parameters.BrandId))
    {
        AddIncludes(p => p.productBrand);
        AddIncludes(p => p.productType);    
        
        // Switch 4 [NameAsc, NameDesc, PriceAsc, PriceDesc]
        switch (parameters.Sort)
        {
            case ProductSortingOptions.NameAsc:
                AddOrderBy(p => p.Name);
                break;
            case ProductSortingOptions.NameDesc:
                AddOrderByDescending(p => p.Name);
                break;
            case ProductSortingOptions.PriceAsc:
                AddOrderBy(p => p.Price);
                break;
            case ProductSortingOptions.PriceDesc:
                AddOrderByDescending(p => p.Price);
                break;
            default:
                break;
        }
    }
    
    // Get Product By Id ==> Includes Type and Brand
    public ProductWithBrandAndTypeSpecification(int id) : base(p => p.Id == id)
    {
        AddIncludes(p => p.productBrand);
        AddIncludes(p => p.productType);
    }
}