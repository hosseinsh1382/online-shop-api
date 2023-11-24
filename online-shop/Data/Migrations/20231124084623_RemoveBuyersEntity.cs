using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace online_shop.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBuyersEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_CartItem_Buyers_BuyerId",
            //     table: "CartItem");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_Comments_Buyers_BuyerId",
            //     table: "Comments");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_Receipt_Buyers_BuyerId",
            //     table: "Receipt");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "AccountRoll");

            migrationBuilder.DropIndex(
                name: "IX_Receipt_BuyerId",
                table: "Receipt");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BuyerId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_BuyerId",
                table: "CartItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountRoll",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Roll = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRoll", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RollId = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Credit = table.Column<double>(type: "double", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Firstname = table.Column<string>(type: "longtext", nullable: true),
                    Lastname = table.Column<string>(type: "longtext", nullable: true),
                    Password = table.Column<string>(type: "longtext", nullable: false),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buyers_AccountRoll_RollId",
                        column: x => x.RollId,
                        principalTable: "AccountRoll",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_BuyerId",
                table: "Receipt",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BuyerId",
                table: "Comments",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_BuyerId",
                table: "CartItem",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_RollId",
                table: "Buyers",
                column: "RollId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Buyers_BuyerId",
                table: "CartItem",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Buyers_BuyerId",
                table: "Comments",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Buyers_BuyerId",
                table: "Receipt",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
