using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class dataseeding : Migration
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
                    { 2, "Self Help Guru", 2, "Unlock your potential and achieve greatness.", "978-0987654321", "", 49.990000000000002, 39.990000000000002, 34.990000000000002, 37.990000000000002, "Self-Help Mastery" },
                    { 3, "Colleen Hoover", 3, "A powerful and heart-wrenching story about love and choices.", "978-0123456789", "", 49.990000000000002, 39.990000000000002, 34.990000000000002, 37.990000000000002, "It Ends With Us" },
                    { 4, "Thriller Mastermind", 4, "A suspenseful journey into the world of mystery and intrigue.", "978-0123456789", "", 44.990000000000002, 34.990000000000002, 28.989999999999998, 31.989999999999998, "The Thriller Code" },
                    { 5, "Fantasy Weaver", 5, "Immerse yourself in a fantastical world of magic and wonder.", "978-5678901234", "", 29.989999999999998, 19.989999999999998, 14.99, 17.989999999999998, "Fantasy Realm" }
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
                name: "Categories");
        }
    }
}
