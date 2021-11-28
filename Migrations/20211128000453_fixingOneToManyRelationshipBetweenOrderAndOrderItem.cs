using Microsoft.EntityFrameworkCore.Migrations;

namespace VPWebSolutions.Migrations
{
    public partial class fixingOneToManyRelationshipBetweenOrderAndOrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Orders_OrderId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderItem");

            migrationBuilder.AddColumn<int>(
                name: "OrderFK",
                table: "OrderItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderFK",
                table: "OrderItem",
                column: "OrderFK");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Orders_OrderFK",
                table: "OrderItem",
                column: "OrderFK",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Orders_OrderFK",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_OrderFK",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "OrderFK",
                table: "OrderItem");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Orders_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
