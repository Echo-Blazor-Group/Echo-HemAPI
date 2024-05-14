using Echo_HemAPI.Controllers;
using Echo_HemAPI.Data.Context;
using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Echo_HemAPI.Data.Repositories.Repos
{
    public class PictureRepository : IPictureRepository
    {
        private readonly ApplicationDbContext _context;

        public PictureRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Picture> AddAsync(Picture entity)
        {
            await _context.Pictures.AddAsync(entity);
            return entity;
        }

        public async Task<IQueryable<Picture>> FindAsync(Expression<Func<Picture, bool>> predicate)
        {
            var entity = await _context.Pictures.FindAsync(predicate);
            return (IQueryable<Picture>)entity;
        }

        public async Task<IEnumerable<Picture>> GetAllAsync()
        {
            return await _context.Pictures.ToListAsync();
        }

        public async Task<Picture> GetByIdAsync(int id)
        {
            return await _context.Pictures.FirstOrDefaultAsync(e => e.Id == id);       
        }

        public async Task<Picture> RemoveAsync(Picture entity)
        {
            _context.Remove(entity);
            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Picture> UpdateAsync(Picture entity)
        {
            _context.Pictures.Update(entity);
            return entity;
        }
    }
}
