﻿// <auto-generated />
using Library.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Library.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Library.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Fiction"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 3,
                            Name = "Self-help"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 2,
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 4,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 5,
                            DisplayOrder = 2,
                            Name = "Fantasy"
                        });
                });

            modelBuilder.Entity("Library.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<double>("ListPrice")
                        .HasColumnType("double precision");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<double>("Price100")
                        .HasColumnType("double precision");

                    b.Property<double>("Price50")
                        .HasColumnType("double precision");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Adventure Author",
                            CategoryId = 1,
                            Description = "An epic adventure filled with twists and turns.",
                            ISBN = "978-1234567890",
                            ImageUrl = "",
                            ListPrice = 39.990000000000002,
                            Price = 29.989999999999998,
                            Price100 = 24.989999999999998,
                            Price50 = 27.989999999999998,
                            Title = "The Adventure Chronicles"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Algorithm Expert",
                            CategoryId = 2,
                            Description = "Master complex algorithms for efficient problem-solving.",
                            ISBN = "978-5432109876",
                            ImageUrl = "",
                            ListPrice = 69.989999999999995,
                            Price = 59.990000000000002,
                            Price100 = 54.990000000000002,
                            Price50 = 57.990000000000002,
                            Title = "Advanced Algorithms"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Web Development Guru",
                            CategoryId = 2,
                            Description = "A comprehensive guide to modern web development techniques.",
                            ISBN = "978-6789012345",
                            ImageUrl = "",
                            ListPrice = 54.990000000000002,
                            Price = 44.990000000000002,
                            Price100 = 39.990000000000002,
                            Price50 = 42.990000000000002,
                            Title = "Web Development Unleashed"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Colleen Hoover",
                            CategoryId = 3,
                            Description = "A powerful and emotionally charged novel exploring complex relationships.",
                            ISBN = "978-1501110368",
                            ImageUrl = "",
                            ListPrice = 32.990000000000002,
                            Price = 26.989999999999998,
                            Price100 = 22.989999999999998,
                            Price50 = 24.989999999999998,
                            Title = "It Ends with Us"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Thriller Writer",
                            CategoryId = 3,
                            Description = "Thrill-seekers, get ready for a rollercoaster of emotions.",
                            ISBN = "978-8901234567",
                            ImageUrl = "",
                            ListPrice = 42.990000000000002,
                            Price = 32.990000000000002,
                            Price100 = 27.989999999999998,
                            Price50 = 30.989999999999998,
                            Title = "Suspenseful Thrillers"
                        },
                        new
                        {
                            Id = 6,
                            Author = "AI Enthusiast",
                            CategoryId = 4,
                            Description = "A guide to understanding and implementing AI concepts.",
                            ISBN = "978-4567890123",
                            ImageUrl = "",
                            ListPrice = 64.989999999999995,
                            Price = 54.990000000000002,
                            Price100 = 49.990000000000002,
                            Price50 = 52.990000000000002,
                            Title = "Artificial Intelligence Essentials"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Jane Austen",
                            CategoryId = 3,
                            Description = "Jane Austen's classic novel about love, class, and societal expectations.",
                            ISBN = "978-0141439518",
                            ImageUrl = "",
                            ListPrice = 28.989999999999998,
                            Price = 22.989999999999998,
                            Price100 = 18.989999999999998,
                            Price50 = 20.989999999999998,
                            Title = "Pride and Prejudice"
                        },
                        new
                        {
                            Id = 8,
                            Author = "War Historian",
                            CategoryId = 5,
                            Description = "An in-depth look at the major conflicts that shaped the world.",
                            ISBN = "978-6789012345",
                            ImageUrl = "",
                            ListPrice = 44.990000000000002,
                            Price = 34.990000000000002,
                            Price100 = 29.989999999999998,
                            Price50 = 32.990000000000002,
                            Title = "World Wars Chronicle"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Mvc.Rendering.SelectListGroup", b =>
                {
                    b.Property<bool>("Disabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.ToTable("SelectListGroup");
                });

            modelBuilder.Entity("Library.Models.Product", b =>
                {
                    b.HasOne("Library.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
