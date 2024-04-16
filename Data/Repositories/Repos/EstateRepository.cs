using Echo_HemAPI.Data.Context;
using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Echo_HemAPI.Data.Repositories.Repos
{

    //Author Gustaf
    public class EstateRepository : IEstateRepository
    {

        private readonly ApplicationDbContext _context;

        public EstateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Estate> AddAsync(Estate entity)
        {
            await _context.Set<Estate>().AddAsync(entity);
            return entity;
        }

        public async Task<IQueryable<Estate>> FindAsync(Expression<Func<Estate, bool>> predicate)
        {
            var entity = await _context.Set<Estate>().FindAsync(predicate);
            return (IQueryable<Estate>)entity;
        }

        public async Task<IEnumerable<Estate>> GetAllAsync()
        {
            return await _context.Set<Estate>().ToListAsync();
        }

        public async Task<Estate> GetByIdAsync(int id)
        {
            return await _context.Set<Estate>().FindAsync(id);
        }

        public async Task<Estate> RemoveAsync(Estate entity)
        {
            _context.Remove(entity);
            return entity;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<Estate> UpdateAsync(Estate entity)
        {
            _context.Set<Estate>().Update(entity);
            return entity;
        }
    }
}
