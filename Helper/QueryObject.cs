using Echo_HemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Echo_HemAPI.Helper
{
    public class QueryObject
    {
        public bool? IsActive { get; set; } = null;
        public string? RealtorFirm { get; set; } = null;

        public static async Task<List<Realtor>?> FilterByQuery(IQueryable<Realtor>? users, QueryObject query)
        {
            if (users is not null)
            {
                if (!string.IsNullOrWhiteSpace(query.RealtorFirm))
                {
                    users = users.Where(u => u.RealtorFirm.Name.Contains(query.RealtorFirm));
                }
                if (query.IsActive is true)
                {
                    users = users.Where(u => u.IsActive == query.IsActive);
                }
                if (query.IsActive is false)
                {
                    users = users.Where(u => u.IsActive == query.IsActive);
                }
                return await users.ToListAsync();
            }
            else
            {
                return null;
            }
        }
    }
}