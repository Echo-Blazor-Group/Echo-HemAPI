using Echo_HemAPI.Data.Models;
using System.Linq.Expressions;

namespace Echo_HemAPI.Data.Repositories
{
    public interface IRealtorRepository
    {
        Task<Realtor> AddAsync(Realtor entity);
        Task<Realtor?> UpdateAsync(Realtor entity);
        Task<Realtor?> GetByIdAsync(string? id); //id will be string cause its a string in identity
        Task<IQueryable<Realtor?>> FindAsync();
        Task<IEnumerable<Realtor>?> GetAllAsync();
        Task<Realtor?> RemoveAsync(Realtor entity);
        Task SaveChangesAsync();
    }
}
