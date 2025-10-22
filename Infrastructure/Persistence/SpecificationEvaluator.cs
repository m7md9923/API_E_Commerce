using Domain.Contracts;
using Domain.Entities;

namespace Persistence;

public static class SpecificationEvaluator
{
    public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> inputQuery, ISpecifications<TEntity, TKey> specifications) where TEntity : BaseEntity<TKey>
    {
        if (specifications.Criteria is not null)
        {
            inputQuery = inputQuery.Where(specifications.Criteria);
        }

        if (specifications.IncludeExpressions.Any())
        {
            // foreach (var includeExpression in specifications.IncludeExpressions)
            // {
            //      inputQuery = inputQuery.Include(includeExpression);
            // }
            
            inputQuery = specifications.IncludeExpressions.Aggregate(inputQuery, (current, includeExpression) => current.Include(includeExpression));
        }
        return inputQuery;
    }
}