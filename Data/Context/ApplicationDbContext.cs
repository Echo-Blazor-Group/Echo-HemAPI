using Microsoft.EntityFrameworkCore;
using Echo_HemAPI.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Echo_HemAPI.Helper;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Echo_HemAPI.Data.Context
{
    //Author: All
    public class ApplicationDbContext : IdentityDbContext<Realtor>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<County> Counties { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<RealtorFirm> RealtorFirms { get; set; }
        public DbSet<Realtor> Realtors { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Picture> Picture { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Seed counties to db
            var counties = SeedCounties.GetCounties();
            modelBuilder.Entity<County>().HasData(counties);

            // TODO: Seeding not working because of nested classes (Picture inside RealtorFirm)

            //// Populate an array of RealtorFirm type, by calling helper class
            //RealtorFirm[] realtorFirms = SeedRealtorFirms.GetRealtorFirms();
            //// Seed realtor firms to db
            //modelBuilder.Entity<RealtorFirm>().OwnsOne(rf => rf.Logotype).HasData(realtorFirms);
        }
    }
}
