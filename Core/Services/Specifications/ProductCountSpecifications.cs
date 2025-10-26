using System.Linq.Expressions;
using Domain.Contracts;
using Domain.Entities.ProductModule;
using Shared.Specifications;

namespace Services.Specifications;

public class ProductCountSpecifications : BaseSpecifications<Product, int>
{
    public ProductCountSpecifications(ProductSpecificationParameters parameters)
        : base(p => (!parameters.TypeId.HasValue || p.TypeId == parameters.TypeId)
                    && (!parameters.BrandId.HasValue || p.BrandId == parameters.BrandId)
                    && (string.IsNullOrEmpty(parameters.Search) || p.Name.ToLower().Contains(parameters.Search)))
        {
            
        }
}