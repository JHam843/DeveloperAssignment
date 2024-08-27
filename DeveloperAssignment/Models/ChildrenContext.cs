using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DeveloperAssignment.Models
{
    public class ChildrenContext : DbContext
    {
        public DbSet<Child> Children { get; set; }
        public ChildrenContext(DbContextOptions<ChildrenContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Child>().HasData(
                new Child { Id = 1, Name = "John Doe", Age = 10 },
                new Child { Id = 2, Name = "Jane Smith", Age = 8 }
            );
        }
    }
}
