using System.Collections.Concurrent;
using Domain.Contracts;
using Domain.Entities;
using Persistence.Data;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly StoreDbContext _dbContext;
    private ConcurrentDictionary<string, object> _repositories = new();

    public UnitOfWork(StoreDbContext dbContext)
    {
        _dbContext = dbContext;
        
    }

    public async Task<int> SaveChangesAsync()
        => await _dbContext.SaveChangesAsync();

    public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
    {
        // return => new GenericRepository<TEntity, TKey>(_dbContext);
        // // each time u want to use a repo ==> create a new instance of it
        
        // can use Dictionary to store the repo instances
        // Key ==> Name of Entity
        // Value ==> Instance of repo
        
        // Dictionary<string, object> 
        
        // var key = typeof(TEntity).Name;
        // var val = _repositories.ContainsKey(key) ? _repositories[key] : _repositories[key] = new GenericRepository<TEntity, TKey>(_dbContext);
        // return (IGenericRepository<TEntity, TKey>)val; // Casting

        return (IGenericRepository<TEntity, TKey>)_repositories.GetOrAdd(typeof(TEntity).Name, (_) => new GenericRepository<TEntity, TKey>(_dbContext));
    }
    
}