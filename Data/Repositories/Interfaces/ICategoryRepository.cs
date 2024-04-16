using Echo_HemAPI.Data.Models;
using System.Linq.Expressions;

namespace Echo_HemAPI.Data.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> AddAsync(Category entity);
        Task<Category> UpdateAsync(Category entity);
        Task<Category?> GetByIdAsync(int id);
        Task<Category> RemoveAsync(Category entity);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<IQueryable<Category>> FindAsync(Expression<Func<Category, bool>> predicate);
        Task SaveChangesAsync();
    }
}
