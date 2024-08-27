using Microsoft.EntityFrameworkCore;

namespace DeveloperAssignment.Models
{
    public class DatabaseAContext : DbContext
    {
        public DatabaseAContext(DbContextOptions<DatabaseAContext> options) : base(options)
        {
        }

        public DbSet<Child> Children { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Child>().HasData(
                new Child { Id = 1, Name = "Alice Brown", Age = 12 },
                new Child { Id = 2, Name = "Bob White", Age = 9 }
            );
        }
    }
}
