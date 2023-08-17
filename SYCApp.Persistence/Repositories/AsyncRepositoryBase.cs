using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SYCApp.Core.Contracts.Persistence;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Persistence.Repositories
{
    public class AsyncRepositoryBase<TEntity> : IAsyncRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        protected SYCAppDbContext _dbContext;

        public AsyncRepositoryBase(SYCAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task Create(TEntity entity)
        {
            // await _dbContext.AddAsync(entity);
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task Update(TEntity entity)
        {
            // In case AsNoTracking is used
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }



        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAll() => _dbContext.Set<TEntity>().CountAsync();

        public Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate)
            => _dbContext.Set<TEntity>().CountAsync(predicate);

    }
}

