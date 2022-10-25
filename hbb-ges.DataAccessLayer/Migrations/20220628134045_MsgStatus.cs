using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hbb_ges.DataAccessLayer.Migrations
{
    public partial class MsgStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Messages");
        }
    }
}
