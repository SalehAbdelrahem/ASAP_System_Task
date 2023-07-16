using Application.Contract;
using Microsoft.EntityFrameworkCore;
using MyDBContext;

namespace Infrastructre
{
    public class GeneralRepository<TEntity, TId> : IGeneralRepository<TEntity, TId> where TEntity : class
    {
        protected readonly TaskDbContext _context;
        protected readonly DbSet<TEntity> _dbset;

        public GeneralRepository(TaskDbContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.FromResult(_dbset);
        }
        public virtual async Task<TEntity?> GetDetailsAsync(TId id)
        {
            var re = await _dbset.FindAsync(id);
            return re;
        }

        public async Task<TEntity> CreateAsync(TEntity item)
        {
            var Item = (await _dbset.AddAsync(item)).Entity;
            _context.SaveChanges();
            return Item;
        }
        public Task<bool> UpdateAsync(TEntity item)
        {
            var entity = _dbset.Update(item);
            _context.SaveChanges();
            if (entity != null)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
        public async Task<bool> DeleteAsync(TId id)
        {
            var item = await GetDetailsAsync(id);
            if (item != null)
            {
                _dbset.Remove(item);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
