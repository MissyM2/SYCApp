using System;
using System.Linq.Expressions;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Core.Contracts.Persistence
{
    public interface IAsyncRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetById(int id);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);

        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> expression);

        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate);
    }
}

