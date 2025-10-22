using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.Contracts;
using Shared.Dtos;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IServiceManager _serviceManager) : ControllerBase
{
    // EndPoint ==> Get All Products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResultDto>>> GetAllProductsAsync(int? typeId, int? brandId)
         => Ok(await _serviceManager.ProductService.GetAllProductsAsync(typeId, brandId));
    // Endpoint ==> Get Product By Id
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductResultDto>> GetProductByIdAsync(int id)
        => Ok(await _serviceManager.ProductService.GetProductByIdAsync(id));
    // Endpoint ==> Get AllBrands
    [HttpGet("brands")]
    public async Task<ActionResult<IEnumerable<BrandResultDto>>> GetAllBrandsAsync()
        => Ok(await _serviceManager.ProductService.GetAllBrandsAsync());
    // Endpoint ==> Get AllTypes
    [HttpGet("types")]
    public async Task<ActionResult<IEnumerable<TypeResultDto>>> GetAllTypesAsync()
        => Ok(await _serviceManager.ProductService.GetAllTypesAsync());
}