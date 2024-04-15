using Echo_HemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Echo_HemAPI.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<RealtorFirm> RealtorFirms { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Estate> Estates { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
