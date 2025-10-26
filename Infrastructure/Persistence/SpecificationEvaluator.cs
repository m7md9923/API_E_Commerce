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

        if (specifications.OrderBy is not null)
        {
            inputQuery = inputQuery.OrderBy(specifications.OrderBy);
        }
        if (specifications.OrderByDescending is not null)
        {
            inputQuery = inputQuery.OrderByDescending(specifications.OrderByDescending);       
        }
        if (specifications.IncludeExpressions.Any())
        {
            // foreach (var includeExpression in specifications.IncludeExpressions)
            // {
            //      inputQuery = inputQuery.Include(includeExpression);
            // }
            
            inputQuery = specifications.IncludeExpressions.Aggregate(inputQuery, (current, includeExpression) => current.Include(includeExpression));
        }

        if (specifications.IsPaginated)
        {
            inputQuery = inputQuery.Skip(specifications.Skip).Take(specifications.Take);       
        }
        return inputQuery;
    }
}