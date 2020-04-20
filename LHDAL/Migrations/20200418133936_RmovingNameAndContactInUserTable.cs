using Microsoft.EntityFrameworkCore.Migrations;

namespace LHDAL.Migrations
{
    public partial class RmovingNameAndContactInUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "LHUser");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "LHUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "LHUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LHUser",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
