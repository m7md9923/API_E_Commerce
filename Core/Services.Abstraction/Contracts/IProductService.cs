using Shared.Dtos;
using Shared.Enums;

namespace Services.Abstraction.Contracts;

public interface IProductService
{
    // GetAllProducts
    Task<IEnumerable<ProductResultDto>> GetAllProductsAsync(int? typeId, int? brandId, ProductSortingOptions sort);
    // GetAllBrands
    Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync();
    // GetAllTypes
    Task<IEnumerable<TypeResultDto>> GetAllTypesAsync();
    // GetProductById
    Task<ProductResultDto> GetProductByIdAsync(int id);
}