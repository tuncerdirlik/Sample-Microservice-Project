using Microsoft.EntityFrameworkCore;
using OrderMicroservice.Application.Contracts;
using OrderMicroservice.Domain.Common;

namespace OrderMicroservice.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseDomainEntity
    {
        private readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(k => k.Id == id && k.Status);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().Where(k => k.Status).ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            entity.Status = false;
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
