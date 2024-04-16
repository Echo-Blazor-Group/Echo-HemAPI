using System.Linq.Expressions;
using Echo_HemAPI.Data.Models;
    /// <summary>
    /// Author: Samed Salman
    /// </summary>

    namespace Echo_HemAPI.Data.Repositories.Interfaces
    {
        public interface IRealtorFirmRepository
        {
            Task<RealtorFirm> AddAsync(RealtorFirm realtorFirm);
            Task<IEnumerable<RealtorFirm>> GetAllAsync();
            Task<RealtorFirm> GetByIdAsync(int id);
            Task<RealtorFirm> RemoveAsync(RealtorFirm realtorFirm);
            Task<RealtorFirm> UpdateAsync(RealtorFirm realtorFirm);
            Task<IQueryable<RealtorFirm>> FindAsync(Expression<Func<RealtorFirm, bool>> predicate);
            Task SaveChangesAsync();
    }
    }
