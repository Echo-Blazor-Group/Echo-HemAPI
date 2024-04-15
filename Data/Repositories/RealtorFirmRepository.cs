
using Echo_HemAPI.Data.Context;

namespace Echo_HemAPI.Data.Models
{
    // Author: Samed Salman
    public class RealtorFirmRepository : IRealtorFirm
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

        public async Task<IQueryable<RealtorFirm>> GetAllRealtorFirmsAsync()
        {
            return _applicationDbContext.RealtorFirms.
        }

        public async Task<RealtorFirm> GetRealtorFirmByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<RealtorFirm> GetRealtorFirmByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<RealtorFirm> RemoveRealtorFirmAsync(RealtorFirm realtorFirm)
        {
            throw new NotImplementedException();
        }

        public async Task<RealtorFirm> UpdateRealtorFirmAsync(RealtorFirm realtorFirm)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }

    }
}