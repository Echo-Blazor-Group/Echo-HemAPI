using Echo_HemAPI.Data.Models;
using System.Linq.Expressions;

namespace Echo_HemAPI.Data.Repositories.Interfaces
{
    //Author Seb
    public interface IRealtorRepository
    {
        Task<Realtor> AddAsync(Realtor entity);
        Task<Realtor?> UpdateAsync(Realtor entity);
        Task<Realtor?> GetByIdAsync(string? id); //id will be string cause its a string in identity
        Task<IEnumerable<Realtor?>?> FindAsync(Expression<Func<Realtor, bool>> predicate);
        Task<IEnumerable<Realtor>?> GetAllAsync();
        Task<Realtor?> RemoveAsync(Realtor entity);
        void SaveChanges();
    }
}
