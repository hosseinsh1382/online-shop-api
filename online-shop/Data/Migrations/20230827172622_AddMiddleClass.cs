using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace online_shop.Migrations
{
    /// <inheritdoc />
    public partial class AddMiddleClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CartItem_ReceiptId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "CartItem");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerId",
                table: "Receipt",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ReceiptCartItems",
                columns: table => new
                {
                    ReceiptId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptCartItems", x => new { x.ReceiptId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ReceiptCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptCartItems_Receipt_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptCartItems_ProductId",
                table: "ReceiptCartItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Buyers_BuyerId",
                table: "Receipt",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Buyers_BuyerId",
                table: "Receipt");

            migrationBuilder.DropTable(
                name: "ReceiptCartItems");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerId",
                table: "Receipt",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Receipt",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ReceiptId",
                table: "CartItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ReceiptId",
                table: "CartItem",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Receipt_ReceiptId",
                table: "CartItem",
                column: "ReceiptId",
                principalTable: "Receipt",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Buyers_BuyerId",
                table: "Receipt",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "Id");
        }
    }
}
