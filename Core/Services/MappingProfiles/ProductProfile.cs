using AutoMapper;
using Domain.Entities.ProductModule;
using Shared.Dtos;

namespace Services.MappingProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductResultDto>()
            .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.productType.Name))
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.productBrand.Name))
            .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<PictureUrlResolver>());
        CreateMap<ProductBrand, BrandResultDto>();
        CreateMap<ProductType, TypeResultDto>();
    }
}