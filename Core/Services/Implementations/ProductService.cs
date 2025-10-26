using AutoMapper;
using Domain.Contracts;
using Domain.Entities.ProductModule;
using Services.Abstraction.Contracts;
using Services.Specifications;
using Shared;
using Shared.Dtos;
using Shared.Enums;
using Shared.Specifications;

namespace Services.Implementations;

public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
{
    public async Task<PaginatedResult<ProductResultDto>> GetAllProductsAsync(ProductSpecificationParameters parameters)
    {
        var specifications = new ProductWithBrandAndTypeSpecification(parameters);
        var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(specifications);
        var productsResult = _mapper.Map<IEnumerable<ProductResultDto>>(products);    
        var pageSize = productsResult.Count();
        var totalCount = await _unitOfWork.GetRepository<Product, int>().CountAsync(new ProductCountSpecifications(parameters));
        return new PaginatedResult<ProductResultDto>(parameters.PageIndex, pageSize, totalCount, productsResult);
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