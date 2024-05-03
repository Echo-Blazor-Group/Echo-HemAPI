using Echo_HemAPI.Data.Context;
using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Echo_HemAPI.Data.Repositories.Repos
{
    public class CountyRepository : ICountyRepository
    {
        private readonly ApplicationDbContext _context;

        public CountyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<County> AddAsync(County entity)
        {
            await _context.Counties.AddAsync(entity);
            return entity;
        }

        public async Task<IQueryable<County>> FindAsync(Expression<Func<County, bool>> predicate)
        {
            var entity = await _context.Counties.FindAsync(predicate);
            return (IQueryable<County>)entity;
        }

        public async Task<IEnumerable<County>> GetAllAsync()
        {
            return await _context.Counties.ToListAsync();
        }

        public async Task<County> GetByIdAsync(int id)
        {
            return await _context.Counties.FindAsync(id);
        }

        public async Task<County> RemoveAsync(County entity)
        {
            _context.Remove(entity);
            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<County> UpdateAsync(County entity)
        {
            _context.Counties.Update(entity);
            return entity;
        }
    }
}
