using Echo_HemAPI.Data.Context;
using Echo_HemAPI.Data.Models.Echo_HemAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Echo_HemAPI.Data.Models
{
    /// <summary>
    /// Author: Samed Salman
    /// </summary>
    public class RealtorFirmRepository : IRealtorFirmRepository
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public RealtorFirmRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<RealtorFirm> AddRealtorFirmAsync(RealtorFirm realtorFirm)
        {
            await _applicationDbContext.AddAsync(realtorFirm);
            return realtorFirm;
        }

        public async Task<IEnumerable<RealtorFirm>> GetAllRealtorFirmsAsync()
        {
            return await _applicationDbContext.RealtorFirms
                                                            .Include(rf => rf.Employees)
                                                            .Include(rf => rf.Estates)
                                                            .OrderBy(rf => rf.Name)
                                                            .ToListAsync();
        }

        public async Task<RealtorFirm> GetRealtorFirmByIdAsync(int id)
        {
            return await _applicationDbContext.RealtorFirms
                                                            .Include(rf => rf.Employees)
                                                            .Include(rf => rf.Estates)
                                                            .FirstOrDefaultAsync(rf => rf.RealtorFirmId == id);
        }

        public async Task<RealtorFirm> RemoveRealtorFirmAsync(RealtorFirm realtorFirm)
        {
            _applicationDbContext.Remove(realtorFirm);
            return realtorFirm;
        }

        public async Task<RealtorFirm> UpdateRealtorFirmAsync(RealtorFirm realtorFirm)
        {
            _applicationDbContext.Update(realtorFirm);
            return realtorFirm;
        }

        public async Task<IQueryable<RealtorFirm>> FindAsync(Expression<Func<RealtorFirm, bool>> predicate)
        {
            var entities = _applicationDbContext.Set<RealtorFirm>().Find(predicate);
            return (IQueryable<RealtorFirm>)entities;
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

    }
}