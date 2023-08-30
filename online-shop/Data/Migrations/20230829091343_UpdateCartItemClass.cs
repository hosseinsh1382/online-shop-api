using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace online_shop.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCartItemClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "CartItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "CartItem",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
