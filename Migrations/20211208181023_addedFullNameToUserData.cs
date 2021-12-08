using Microsoft.EntityFrameworkCore.Migrations;

namespace VPWebSolutions.Migrations
{
    public partial class addedFullNameToUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "UserDatas");
        }
    }
}
