using Microsoft.EntityFrameworkCore.Migrations;

namespace VPWebSolutions.Migrations.BusinessDb
{
    public partial class AddedFKonCheckoutModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "CheckOut",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OrderFK",
                table: "CheckOut",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CheckOut_OrderId",
                table: "CheckOut",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOut_Orders_OrderId",
                table: "CheckOut",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOut_Orders_OrderId",
                table: "CheckOut");

            migrationBuilder.DropIndex(
                name: "IX_CheckOut_OrderId",
                table: "CheckOut");

            migrationBuilder.DropColumn(
                name: "OrderFK",
                table: "CheckOut");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "CheckOut",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
