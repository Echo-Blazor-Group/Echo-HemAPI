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
        public Task<Estate> AddAsync(Estate entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Estate>> FindAsync(Expression<Func<Estate, bool>> preidcate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Estate>> GetAllAsync()
        {
            return await _context.Set<Estate>().ToListAsync();
        }

        public Task<Estate> GetByIdAsync(Guid id)
        {
            return await _context.Set<Estate>().FindAsync(id);
        }

        public Task<Estate> RemoveAsync(Estate estate)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Estate> UpdateAsync(Estate entity)
        {
            throw new NotImplementedException();
        }
    }
}
