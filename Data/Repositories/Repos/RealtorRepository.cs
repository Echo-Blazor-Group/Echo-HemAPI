using Echo_HemAPI.Data.Context;
using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Echo_HemAPI.Data.Repositories.Repos
{
    //Author Seb
    public class RealtorRepository : IRealtorRepository
    {
        public readonly ApplicationDbContext _context;
        public RealtorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Realtor> AddAsync(Realtor entity)
        {
            await _context.Realtors.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<Realtor>?> GetAllAsync()
        {
            var realtors = await _context.Realtors
                                                  .Include(r => r.RealtorFirm)
                                                  .OrderBy(r => r.LastName)
                                                  .ThenBy(r => r.FirstName)
                                                  .ToListAsync();
            if (realtors is null)
            {
                return null;
            }
            else
            {
                return realtors;
            }

        }

        public async Task<Realtor?> GetByIdAsync(string? id)
        {
            var realtor = await _context.Realtors.FirstOrDefaultAsync(x => x.Id == id);

            if (realtor is null)
            {
                return null;
            }
            else
            {
                return realtor;
            }

        }

        public async Task<IEnumerable<Realtor?>?> FindAsync(Expression<Func<Realtor, bool>> predicate)
        {
            var oneOrManyRealtors = await _context.Realtors.AsQueryable().Where(predicate).ToListAsync();
            if (oneOrManyRealtors.Count == 0)
            {
                return null;
            }
            else
            {
                return oneOrManyRealtors;
            }
        }

        public async Task<Realtor?> RemoveAsync(Realtor entity)
        {
            var realtor = await _context.Realtors.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (realtor is null)
            {
                return null;
            }
            else
            {
                _context.Realtors.Remove(entity);
                return realtor;
            }
        }

        public async Task<Realtor?> UpdateAsync(Realtor entity)
        {
            var realtor = await _context.Realtors.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (realtor is null)
            {
                return null;
            }
            else
            {
                _context.Realtors.Update(realtor);
                return realtor;
            }
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
