
using Microsoft.EntityFrameworkCore;

namespace Echo_HemAPI.TestGeneric_Repository
{
    //Where TEntity : class makes the TEntity be a class to get rid of compilation errors
    public class GRepository<TEntity> : IGRepository<TEntity>
        where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        public GRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _context.Set<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

    }
}
