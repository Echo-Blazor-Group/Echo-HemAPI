using Echo_HemAPI.Data.Context;
using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Echo_HemAPI.Data.Repositories.Repos
{
    // Author: Samed Salman
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
            return _applicationDbContext.RealtorFirms.Include(rf => rf.Employees).Include(rf => rf.Estates).OrderBy(rf => rf.Name).AsEnumerable();
        }

        public async Task<RealtorFirm> GetRealtorFirmByIdAsync(int id)
        {
            return await _applicationDbContext.RealtorFirms.Include(rf => rf.Employees).Include(rf => rf.Estates).FirstOrDefaultAsync.(rf => rf.RealtorFirmId == id);
        }

        public async Task<RealtorFirm> GetRealtorFirmByNameAsync(string name)
        {
            return await _applicationDbContext.RealtorFirms.Include(rf => rf.Employees).Include(rf => rf.Estates).FirstOrDefaultAsync.(rf => rf.Name == name);
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

        public async Task SaveChangesAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }

    }
}