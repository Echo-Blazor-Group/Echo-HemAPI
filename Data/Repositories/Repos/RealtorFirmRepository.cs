using Echo_HemAPI.Data.Context;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Echo_HemAPI.Data.Models
{
    /// <summary>
    /// Author: Samed Salman
    /// </summary>
    public class RealtorFirmRepository : IRealtorFirmRepository
    {

        private readonly ApplicationDbContext _context;

        public RealtorFirmRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RealtorFirm> AddAsync(RealtorFirm realtorFirm)
        {
            await _context.AddAsync(realtorFirm);
            return realtorFirm;
        }

        public async Task<IEnumerable<RealtorFirm>> GetAllAsync()
        {
            return await _context.RealtorFirms
                                            .OrderBy(rf => rf.Name)
                                            .ToListAsync();
        }

        public async Task<RealtorFirm> GetByIdAsync(int id)
        {
            return await _context.RealtorFirms
                                            .FirstOrDefaultAsync(rf => rf.Id == id);
        }

        public async Task<RealtorFirm> RemoveAsync(RealtorFirm realtorFirm)
        {
            _context.Remove(realtorFirm);
            return realtorFirm;
        }

        public async Task<RealtorFirm> UpdateAsync(RealtorFirm realtorFirm)
        {
            _context.Update(realtorFirm);
            return realtorFirm;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}