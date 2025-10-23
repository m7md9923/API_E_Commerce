using AutoMapper;
using Domain.Contracts;
using Domain.Entities.ProductModule;
using Services.Abstraction.Contracts;
using Services.Specifications;
using Shared.Dtos;
using Shared.Enums;

namespace Services.Implementations;

public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
{
    public async Task<IEnumerable<ProductResultDto>> GetAllProductsAsync(int? typeId, int? brandId, ProductSortingOptions sort)
    {
        var specifications = new ProductWithBrandAndTypeSpecification(typeId, brandId, sort);
        var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(specifications);
        return _mapper.Map<IEnumerable<ProductResultDto>>(products);
    }

    public async Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync()
    {
        // 1] UnitOfWork ==> GenericRepo ==> GetAllBrands() ==> IEnumerable<ProductBrand>
        var brands = await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
        // Mapping ==> IEnumerable<ProductBrand> ==> IEnumerable<BrandResultDto> [AutoMapper]
        return _mapper.Map<IEnumerable<BrandResultDto>>(brands);
    }

    public async Task<IEnumerable<TypeResultDto>> GetAllTypesAsync()
    {
        var types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
        return _mapper.Map<IEnumerable<TypeResultDto>>(types);
    }

    public async Task<ProductResultDto> GetProductByIdAsync(int id)
    {
        var specifications = new ProductWithBrandAndTypeSpecification(id);
        var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(specifications);
        return _mapper.Map<ProductResultDto>(product);
    }
}