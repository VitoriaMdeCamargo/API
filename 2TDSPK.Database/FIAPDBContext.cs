using _2TDSPK.Database.Mappings;
using _2TDSPK.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace _2TDSPK.Database
{
    public class FIAPDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public FIAPDBContext(DbContextOptions<FIAPDBContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
