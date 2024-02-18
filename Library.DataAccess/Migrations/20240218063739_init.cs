using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SelectListGroup",
                columns: table => new
                {
                    Disabled = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ISBN = table.Column<string>(type: "text", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: false),
                    ListPrice = table.Column<double>(type: "double precision", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Price50 = table.Column<double>(type: "double precision", nullable: false),
                    Price100 = table.Column<double>(type: "double precision", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Fiction" },
                    { 2, 3, "Self-help" },
                    { 3, 2, "Romance" },
                    { 4, 4, "Thriller" },
                    { 5, 2, "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Adventure Author", 1, "An epic adventure filled with twists and turns.", "978-1234567890", "", 39.990000000000002, 29.989999999999998, 24.989999999999998, 27.989999999999998, "The Adventure Chronicles" },
                    { 2, "Algorithm Expert", 2, "Master complex algorithms for efficient problem-solving.", "978-5432109876", "", 69.989999999999995, 59.990000000000002, 54.990000000000002, 57.990000000000002, "Advanced Algorithms" },
                    { 3, "Web Development Guru", 2, "A comprehensive guide to modern web development techniques.", "978-6789012345", "", 54.990000000000002, 44.990000000000002, 39.990000000000002, 42.990000000000002, "Web Development Unleashed" },
                    { 4, "Colleen Hoover", 3, "A powerful and emotionally charged novel exploring complex relationships.", "978-1501110368", "", 32.990000000000002, 26.989999999999998, 22.989999999999998, 24.989999999999998, "It Ends with Us" },
                    { 5, "Thriller Writer", 3, "Thrill-seekers, get ready for a rollercoaster of emotions.", "978-8901234567", "", 42.990000000000002, 32.990000000000002, 27.989999999999998, 30.989999999999998, "Suspenseful Thrillers" },
                    { 6, "AI Enthusiast", 4, "A guide to understanding and implementing AI concepts.", "978-4567890123", "", 64.989999999999995, 54.990000000000002, 49.990000000000002, 52.990000000000002, "Artificial Intelligence Essentials" },
                    { 7, "Jane Austen", 3, "Jane Austen's classic novel about love, class, and societal expectations.", "978-0141439518", "", 28.989999999999998, 22.989999999999998, 18.989999999999998, 20.989999999999998, "Pride and Prejudice" },
                    { 8, "War Historian", 5, "An in-depth look at the major conflicts that shaped the world.", "978-6789012345", "", 44.990000000000002, 34.990000000000002, 29.989999999999998, 32.990000000000002, "World Wars Chronicle" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SelectListGroup");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
