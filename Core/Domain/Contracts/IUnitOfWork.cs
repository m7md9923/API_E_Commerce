using Domain.Entities;

namespace Domain.Contracts;

public interface IUnitOfWork
{
    // Complete, SaveChangesAsync
    
    Task<int> SaveChangesAsync();
    // 2] Method return obj from generic repo [Entity]

    IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    
}