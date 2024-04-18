using Echo_HemAPI.Data.Models;
using System.Linq.Expressions;

namespace Echo_HemAPI.Data.Repositories.Interfaces
{
    public interface IPictureRepository
    {
        Task<Picture> AddAsync(Picture entity);
        Task<Picture> UpdateAsync(Picture entity);
        Task<Picture?> GetByIdAsync(int id);
        Task<Picture> RemoveAsync(Picture entity);
        Task<IEnumerable<Picture>> GetAllAsync();
        Task<IQueryable<Picture>> FindAsync(Expression<Func<Picture, bool>> predicate);
        Task SaveChangesAsync();
    }
}
