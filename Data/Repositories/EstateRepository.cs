using Echo_HemAPI.Data.Context;
using Echo_HemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Echo_HemAPI.Data.Repositories
{
    public class EstateRepository : IEstateRepository
    {

        private readonly ApplicationDbContext _context;

        public EstateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Estate> AddAsync(Estate entity)
        {
             _context.Set<Estate>().Add(entity);
            return entity;
        }

        public async Task<IEnumerable<Estate>> FindAsync(Expression<Func<Estate, bool>> preidcate)
        {
            return  _context.Set<Estate>(); 
        }

        public async Task<IEnumerable<Estate>> GetAllAsync()
        {
            return await _context.Set<Estate>().ToListAsync();
        }

        public async Task<Estate> GetByIdAsync(Guid id)
        {
            return await _context.Set<Estate>().FindAsync(id);
        }

        public async Task<Estate> RemoveAsync(Estate entity)
        {
            _context.Remove(entity);
            return entity;
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<Estate> UpdateAsync(Estate entity)
        {
            _context.Set<Estate>().Update(entity);
            return entity;
        }
    }
}
