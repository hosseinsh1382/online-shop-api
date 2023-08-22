using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace online_shop.Migrations
{
    /// <inheritdoc />
    public partial class AddStationeryEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Products",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaperCount",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PencilTypeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pencil_ColorId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PencileTypeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PencilType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PencilType", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PenColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Color = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PenColor", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColorId",
                table: "Products",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Pencil_ColorId",
                table: "Products",
                column: "Pencil_ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PencilTypeId",
                table: "Products",
                column: "PencilTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PenColor_ColorId",
                table: "Products",
                column: "ColorId",
                principalTable: "PenColor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PenColor_Pencil_ColorId",
                table: "Products",
                column: "Pencil_ColorId",
                principalTable: "PenColor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PencilType_PencilTypeId",
                table: "Products",
                column: "PencilTypeId",
                principalTable: "PencilType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_PenColor_ColorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_PenColor_Pencil_ColorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_PencilType_PencilTypeId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "PencilType");

            migrationBuilder.DropTable(
                name: "PenColor");

            migrationBuilder.DropIndex(
                name: "IX_Products_ColorId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Pencil_ColorId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PencilTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PaperCount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PencilTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Pencil_ColorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PencileTypeId",
                table: "Products");
        }
    }
}
