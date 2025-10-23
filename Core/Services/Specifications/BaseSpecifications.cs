﻿using System.Linq.Expressions;
using Domain.Contracts;
using Domain.Entities;

namespace Services.Specifications;

public abstract class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    
    #region Criteria

    protected BaseSpecifications(Expression<Func<TEntity, bool>> criteria)
    {
        Criteria = criteria;
    }
    public Expression<Func<TEntity, bool>> Criteria { get; private set; }
    
    #endregion

    #region Include
    
    public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = []; 

    protected void AddIncludes(Expression<Func<TEntity, object>> include) 
    {
        IncludeExpressions.Add(include);
    }
    
    #endregion
    
    #region OrderBy
    
    public Expression<Func<TEntity, object>> OrderBy { get; private set; }
    public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }
    
    protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        => OrderBy = orderByExpression;
    
    
    protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression)
        => OrderByDescending = orderByDescendingExpression;
    
    #endregion
    
}