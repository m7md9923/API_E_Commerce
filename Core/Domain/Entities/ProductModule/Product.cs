namespace Domain.Entities.ProductModule;

public class Product : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public string PictureUrl { get; set; } = string.Empty;
    
    public decimal Price { get; set; }
    
    // 1: M ProductType
    // 1: M ProductBrand
    
    public ProductType productType { get; set; } // Nav Prop
    public int TypeId { get; set; }  // FK
    
    public ProductBrand productBrand { get; set; } // Nav Prop
    public int BrandId { get; set; } // FK
    
}