using Microsoft.EntityFrameworkCore.Migrations;

namespace LHDAL.Migrations
{
    public partial class InitialCreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "LHUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserEmail = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LHUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LHUrl",
                columns: table => new
                {
                    UrlId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlTitle = table.Column<string>(nullable: true),
                    LHUrlName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LHUrl", x => x.UrlId);
                    table.ForeignKey(
                        name: "FK_LHUrl_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LHUrl_LHUser_Id",
                        column: x => x.Id,
                        principalTable: "LHUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LHUrl_CategoryId",
                table: "LHUrl",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LHUrl_Id",
                table: "LHUrl",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LHUrl");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "LHUser");
        }
    }
}
