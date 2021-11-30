using Microsoft.EntityFrameworkCore.Migrations;

namespace VPWebSolutions.Migrations.BusinessDb
{
    public partial class addedIsGuestBoolForOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isGuestUser",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isGuestUser",
                table: "Orders");
        }
    }
}
