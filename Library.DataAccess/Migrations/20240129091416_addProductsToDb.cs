using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addProductsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Price100 = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Adventure Author", "An epic adventure filled with twists and turns.", "978-1234567890", 39.990000000000002, 29.989999999999998, 24.989999999999998, 27.989999999999998, "The Adventure Chronicles" },
                    { 2, "Self Help Guru", "Unlock your potential and achieve greatness.", "978-0987654321", 49.990000000000002, 39.990000000000002, 34.990000000000002, 37.990000000000002, "Self-Help Mastery" },
                    { 3, "Colleen Hoover", "A powerful and heart-wrenching story about love and choices.", "978-0123456789", 49.990000000000002, 39.990000000000002, 34.990000000000002, 37.990000000000002, "It Ends With Us" },
                    { 4, "Thriller Mastermind", "A suspenseful journey into the world of mystery and intrigue.", "978-0123456789", 44.990000000000002, 34.990000000000002, 28.989999999999998, 31.989999999999998, "The Thriller Code" },
                    { 5, "Fantasy Weaver", "Immerse yourself in a fantastical world of magic and wonder.", "978-5678901234", 29.989999999999998, 19.989999999999998, 14.99, 17.989999999999998, "Fantasy Realm" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
