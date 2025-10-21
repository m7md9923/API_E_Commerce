using System.Linq.Expressions;
using System.Reflection;
using AutoMapper;
using AutoMapper.Execution;
using AutoMapper.Internal;
using Domain.Entities.ProductModule;
using Microsoft.Extensions.Configuration;
using Shared.Dtos;

namespace Services.MappingProfiles;

public class PictureUrlResolver(IConfiguration _configuration) : IValueResolver<Product, ProductResultDto, string>
{
    public string Resolve(Product source, ProductResultDto destination, string destMember, ResolutionContext context)
    {
        // (src => $"https://localhost:7259/{src.PictureUrl}")
        if (string.IsNullOrEmpty(source.PictureUrl))
        {
            return String.Empty;
        }
        return $"{_configuration.GetSection("URLS")["BaseURL"]}{source.PictureUrl}";
    }
}