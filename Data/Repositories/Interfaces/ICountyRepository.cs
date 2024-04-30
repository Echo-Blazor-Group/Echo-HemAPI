using Echo_HemAPI.Data.Models;
using System.Linq.Expressions;

namespace Echo_HemAPI.Data.Repositories.Interfaces
{
    public interface ICountyRepository
    {
        Task<County> AddAsync(County entity);
        Task<County> UpdateAsync(County entity);
        Task<County?> GetByIdAsync(int id);
        Task<County> RemoveAsync(County entity);
        Task<IEnumerable<County>> GetAllAsync();
        Task<IQueryable<County>> FindAsync(Expression<Func<County, bool>> predicate);
        Task SaveChangesAsync();
    }
}
