using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Contracts;

public interface ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    // Signature for Prop [Expression Where]
    public Expression<Func<TEntity, bool>> Criteria { get; }   
    
    // Signature for Prop [Expression Include]
    public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; }
}