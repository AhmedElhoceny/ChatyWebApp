using Microsoft.EntityFrameworkCore.Migrations;

namespace Chaty.Migrations
{
    public partial class AddPropertiestoMessageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Messages");
        }
    }
}
