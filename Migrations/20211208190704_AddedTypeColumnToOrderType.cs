using Microsoft.EntityFrameworkCore.Migrations;

namespace VPWebSolutions.Migrations
{
    public partial class AddedTypeColumnToOrderType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Carts_CartId",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_CartId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "OrderItems");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CartId",
                table: "OrderItems",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Carts_CartId",
                table: "OrderItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
