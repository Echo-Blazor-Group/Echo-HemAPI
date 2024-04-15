using Microsoft.EntityFrameworkCore;

namespace Echo_HemAPI.TestGeneric_Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

    }
}
