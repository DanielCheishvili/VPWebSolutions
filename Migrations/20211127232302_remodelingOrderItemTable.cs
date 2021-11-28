using Microsoft.EntityFrameworkCore.Migrations;

namespace VPWebSolutions.Migrations
{
    public partial class remodelingOrderItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_MenuItem_MenuItemId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_MenuItemId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "MenuItem_Id",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuItem_Id",
                table: "OrderItems",
                column: "MenuItem_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_MenuItem_MenuItem_Id",
                table: "OrderItems",
                column: "MenuItem_Id",
                principalTable: "MenuItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_MenuItem_MenuItem_Id",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_MenuItem_Id",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "MenuItem_Id",
                table: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "MenuItemId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuItemId",
                table: "OrderItems",
                column: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_MenuItem_MenuItemId",
                table: "OrderItems",
                column: "MenuItemId",
                principalTable: "MenuItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
