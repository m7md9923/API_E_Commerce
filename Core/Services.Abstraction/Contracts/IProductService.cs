using Shared.Dtos;
using Shared.Enums;
using Shared.Specifications;

namespace Services.Abstraction.Contracts;

public interface IProductService
{
    // GetAllProducts
    Task<IEnumerable<ProductResultDto>> GetAllProductsAsync(ProductSpecificationParameters parameters);
    // GetAllBrands
    Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync();
    // GetAllTypes
    Task<IEnumerable<TypeResultDto>> GetAllTypesAsync();
    // GetProductById
    Task<ProductResultDto> GetProductByIdAsync(int id);
}