using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace online_shop.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BicycleTypeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comapny",
                table: "Products",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAutomate",
                table: "Products",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotorCapacity",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BicycleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BicycleType", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BicycleTypeId",
                table: "Products",
                column: "BicycleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_BicycleType_BicycleTypeId",
                table: "Products",
                column: "BicycleTypeId",
                principalTable: "BicycleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_BicycleType_BicycleTypeId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "BicycleType");

            migrationBuilder.DropIndex(
                name: "IX_Products_BicycleTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BicycleTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Comapny",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsAutomate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MotorCapacity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");
        }
    }
}
