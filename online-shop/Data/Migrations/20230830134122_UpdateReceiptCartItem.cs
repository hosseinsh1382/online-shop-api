using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace online_shop.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReceiptCartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "ReceiptCartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "Credit",
                table: "Buyers",
                type: "double",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "ReceiptCartItems");

            migrationBuilder.AlterColumn<double>(
                name: "Credit",
                table: "Buyers",
                type: "double",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true);
        }
    }
}
