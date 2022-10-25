using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hbb_ges.DataAccessLayer.Migrations
{
    public partial class MapcolumnAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Map",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Map",
                table: "Contacts");
        }
    }
}
