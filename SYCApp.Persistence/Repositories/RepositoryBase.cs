using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SYCApp.Core.Contracts.Persistence;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Persistence.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected SYCAppDbContext _dbContext;

        public RepositoryBase(SYCAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> FindAll() => _dbContext.Set<TEntity>().AsNoTracking();

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Where(expression).AsNoTracking();
        } 

        public void Create(TEntity entity) =>_dbContext.Add(entity);

        public void Delete(TEntity entity) =>_dbContext.Set<TEntity>().Remove(entity);

        public void Update(TEntity entity) => _dbContext.Update(entity);

    }
}

