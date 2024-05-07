using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Models.DTOs;
using System.Linq.Expressions;

namespace Echo_HemAPI.Data.Repositories.Interfaces
{
    //Author Gustaf
    public interface IEstateRepository
    {
        Task<Estate> AddAsync(Estate entity, Realtor realtor, Category category, County county);
        Task<Estate> UpdateAsync(Estate entity);
        Task<Estate?> GetByIdAsync(int id);
        Task<Estate> RemoveAsync(Estate entity);
        Task<IEnumerable<Estate>?> GetAllAsync();
        Task<IQueryable<Estate?>?> FindAsync(Expression<Func<Estate, bool>> predicate);
        Task SaveChangesAsync();
   
    }
}
