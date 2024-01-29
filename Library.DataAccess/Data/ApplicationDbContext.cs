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
                Price100 = 24.99
            },
            new Product
            {
                Id = 2,
                Title = "Self-Help Mastery",
                Description = "Unlock your potential and achieve greatness.",
                ISBN = "978-0987654321",
                Author = "Self Help Guru",
                ListPrice = 49.99,
                Price = 39.99,
                Price50 = 37.99,
                Price100 = 34.99
            },
            new Product
            {
                Id = 3,
                Title = "It Ends With Us",
                Description = "A powerful and heart-wrenching story about love and choices.",
                ISBN = "978-0123456789",
                Author = "Colleen Hoover",
                ListPrice = 49.99,
                Price = 39.99,
                Price50 = 37.99,
                Price100 = 34.99
            },
            new Product
            {
                Id = 4,
                Title = "The Thriller Code",
                Description = "A suspenseful journey into the world of mystery and intrigue.",
                ISBN = "978-0123456789",
                Author = "Thriller Mastermind",
                ListPrice = 44.99,
                Price = 34.99,
                Price50 = 31.99,
                Price100 = 28.99
            },
            new Product
            {
                Id = 5,
                Title = "Fantasy Realm",
                Description = "Immerse yourself in a fantastical world of magic and wonder.",
                ISBN = "978-5678901234",
                Author = "Fantasy Weaver",
                ListPrice = 29.99,
                Price = 19.99,
                Price50 = 17.99,
                Price100 = 14.99
            }
        );


        }
    }
        
}
