using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_CommerceAPI.Migrations
{
    /// <inheritdoc />
    public partial class eCormmercecategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "eSubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_eSubCategories_eCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "eCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_eSubCategories_CategoryId",
                table: "eSubCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eSubCategories");

            migrationBuilder.DropTable(
                name: "eCategory");
        }
    }
}
