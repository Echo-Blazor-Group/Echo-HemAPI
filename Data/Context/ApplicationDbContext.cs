using Microsoft.EntityFrameworkCore;
using Echo_HemAPI.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Echo_HemAPI.Helper;


namespace Echo_HemAPI.Data.Context
{
    //Author All
    public class ApplicationDbContext : IdentityDbContext<Realtor>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<County> Counties { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<RealtorFirm> RealtorFirms { get; set; }
        public DbSet<Realtor> Realtors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var counties = SeedCounties.GetCounties();
            modelBuilder.Entity<County>().HasData(counties);
            base.OnModelCreating(modelBuilder);
        }
    }
}
