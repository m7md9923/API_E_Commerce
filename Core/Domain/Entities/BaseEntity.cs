namespace Domain.Entities;

public class BaseEntity<TKey>  // Generic class [BaseClass] Specify the PK type
{
    public TKey Id { get; set; }  
    
}