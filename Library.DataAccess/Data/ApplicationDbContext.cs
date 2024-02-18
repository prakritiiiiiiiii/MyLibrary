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


            },

            new Product
            {
                Id = 2,
                Title = "Advanced Algorithms",
                Description = "Master complex algorithms for efficient problem-solving.",
                ISBN = "978-5432109876",
                Author = "Algorithm Expert",
                ListPrice = 69.99,
                Price = 59.99,
                Price50 = 57.99,
                Price100 = 54.99,
                CategoryId = 2,
                ImageUrl = ""
            },
            new Product
            {
                Id = 3,
                Title = "Web Development Unleashed",
                Description = "A comprehensive guide to modern web development techniques.",
                ISBN = "978-6789012345",
                Author = "Web Development Guru",
                ListPrice = 54.99,
                Price = 44.99,
                Price50 = 42.99,
                Price100 = 39.99,
                CategoryId = 2,
                ImageUrl = ""
            },
            // Category 3
            new Product
            {
                Id = 4,
                Title = "It Ends with Us",
                Description = "A powerful and emotionally charged novel exploring complex relationships.",
                ISBN = "978-1501110368",
                Author = "Colleen Hoover",
                ListPrice = 32.99,
                Price = 26.99,
                Price50 = 24.99,
                Price100 = 22.99,
                CategoryId = 3,
                ImageUrl = ""
            },
            new Product
            {
                Id = 5,
                Title = "Suspenseful Thrillers",
                Description = "Thrill-seekers, get ready for a rollercoaster of emotions.",
                ISBN = "978-8901234567",
                Author = "Thriller Writer",
                ListPrice = 42.99,
                Price = 32.99,
                Price50 = 30.99,
                Price100 = 27.99,
                CategoryId = 3,
                ImageUrl = ""
            },
            // Category 4
            new Product
            {
                Id = 6,
                Title = "Artificial Intelligence Essentials",
                Description = "A guide to understanding and implementing AI concepts.",
                ISBN = "978-4567890123",
                Author = "AI Enthusiast",
                ListPrice = 64.99,
                Price = 54.99,
                Price50 = 52.99,
                Price100 = 49.99,
                CategoryId = 4,
                ImageUrl = ""
            },

             // Category 5
             new Product
             {
                 Id = 7,
                 Title = "Pride and Prejudice",
                 Description = "Jane Austen's classic novel about love, class, and societal expectations.",
                 ISBN = "978-0141439518",
                 Author = "Jane Austen",
                 ListPrice = 28.99,
                 Price = 22.99,
                 Price50 = 20.99,
                 Price100 = 18.99,
                 CategoryId = 3,
                 ImageUrl = ""
             },
            new Product
            {
                Id = 8,
                Title = "World Wars Chronicle",
                Description = "An in-depth look at the major conflicts that shaped the world.",
                ISBN = "978-6789012345",
                Author = "War Historian",
                ListPrice = 44.99,
                Price = 34.99,
                Price50 = 32.99,
                Price100 = 29.99,
                CategoryId = 5,
                ImageUrl = ""
            });
            


         
            
            modelBuilder.Entity<SelectListGroup>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }



    }
        
}
