using System.Linq.Expressions;
using Echo_HemAPI.Data.Models;
    /// <summary>
    /// Author: Samed Salman
    /// </summary>

    namespace Echo_HemAPI.Data.Repositories.Interfaces
    {
        public interface IRealtorFirmRepository
        {
            Task<RealtorFirm> AddRealtorFirmAsync(RealtorFirm realtorFirm);
            Task<IEnumerable<RealtorFirm>> GetAllRealtorFirmsAsync();
            Task<RealtorFirm> GetRealtorFirmByIdAsync(int id);
            Task<RealtorFirm> RemoveRealtorFirmAsync(RealtorFirm realtorFirm);
            Task<RealtorFirm> UpdateRealtorFirmAsync(RealtorFirm realtorFirm);
            Task<IQueryable<RealtorFirm>> FindAsync(Expression<Func<RealtorFirm, bool>> predicate);
            void SaveChanges();
        }
    }
