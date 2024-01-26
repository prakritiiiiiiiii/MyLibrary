using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 

        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fiction", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Self-help", DisplayOrder = 3 },
                new Category { Id = 3, Name = "Romance", DisplayOrder = 2 },
                new Category { Id = 4, Name = "Thriller", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Fantasy", DisplayOrder = 2 }

                );
        }
    }
        
}
