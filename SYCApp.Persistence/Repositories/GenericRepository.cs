using System;
using Microsoft.EntityFrameworkCore;
using SYCApp.Core.Contracts.Persistence;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SYCAppDbContext _dbContext;

        public GenericRepository(SYCAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> GetAsync(int? id)
        {
            var result = await _dbContext.Set<TEntity>().FindAsync(id);
            return result;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            _dbContext.Set<TEntity>().Remove(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }


        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _dbContext.Set<TEntity>().AnyAsync(q => q.Id == id);
        }


    }
}

