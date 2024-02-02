using Library.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fiction", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Self-help", DisplayOrder = 3 },
                new Category { Id = 3, Name = "Romance", DisplayOrder = 2 },
                new Category { Id = 4, Name = "Thriller", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Fantasy", DisplayOrder = 2 }

                );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Title = "The Adventure Chronicles",
                Description = "An epic adventure filled with twists and turns.",
                ISBN = "978-1234567890",
                Author = "Adventure Author",
                ListPrice = 39.99,
                Price = 29.99,
                Price50 = 27.99,
                Price100 = 24.99,
                CategoryId = 1,
                ImageUrl = ""


            }

         );
            
            modelBuilder.Entity<SelectListGroup>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }



    }
        
}
