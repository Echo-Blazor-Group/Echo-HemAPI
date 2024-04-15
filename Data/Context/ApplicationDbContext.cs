using Microsoft.EntityFrameworkCore;
using Echo_HemAPI.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Echo_HemAPI.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<Realtor>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    
        public DbSet<County> Counties { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<RealtorFirm> RealtorFirms { get; set; }
        public DbSet<Realtor> Realtors { get; set; }

        
    }
}
