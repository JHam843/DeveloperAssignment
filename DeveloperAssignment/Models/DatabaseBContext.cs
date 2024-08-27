using Microsoft.EntityFrameworkCore;

namespace DeveloperAssignment.Models
{
    public class DatabaseBContext : DbContext
    {
        public DatabaseBContext(DbContextOptions<DatabaseBContext> options) : base(options)
        {
        }

        public DbSet<Child> Children { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Child>().HasData(
                new Child { Id = 1, Name = "Charlie Black", Age = 11 },
                new Child { Id = 2, Name = "Daisy Green", Age = 10 }
            );
        }
    }
}
