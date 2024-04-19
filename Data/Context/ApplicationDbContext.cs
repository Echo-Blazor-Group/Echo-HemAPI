using Microsoft.EntityFrameworkCore;
using Echo_HemAPI.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Echo_HemAPI.Helper;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        //Author Seb
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Seed counties to db
            var counties = SeedCounties.GetCounties();
            modelBuilder.Entity<County>().HasData(counties);
            
            // Seed categories to db
            var categories = SeedCategories.GetCategories();
            modelBuilder.Entity<Category>().HasData(categories);

            //var estates = SeedEstates.GetEstates();
            //modelBuilder.Entity<Estate>().HasData(counties);
        }
    }
}
