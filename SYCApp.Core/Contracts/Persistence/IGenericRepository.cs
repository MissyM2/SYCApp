using System;
namespace SYCApp.Core.Contracts.Persistence
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int? id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task UpdateAsync(TEntity entity);
        Task<bool> Exists(int id);
    }
}

