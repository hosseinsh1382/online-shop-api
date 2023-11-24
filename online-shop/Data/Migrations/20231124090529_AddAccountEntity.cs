using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace online_shop.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Receipt",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "CartItem",
                type: "int",
                nullable: true);

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
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Firstname = table.Column<string>(type: "longtext", nullable: true),
                    Lastname = table.Column<string>(type: "longtext", nullable: true),
                    Credit = table.Column<double>(type: "double", nullable: true),
                    RollId = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountRoll_RollId",
                        column: x => x.RollId,
                        principalTable: "AccountRoll",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_AccountId",
                table: "Receipt",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AccountId",
                table: "Comments",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_AccountId",
                table: "CartItem",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RollId",
                table: "Accounts",
                column: "RollId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Accounts_AccountId",
                table: "CartItem",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Accounts_AccountId",
                table: "Comments",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Accounts_AccountId",
                table: "Receipt",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Accounts_AccountId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Accounts_AccountId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Accounts_AccountId",
                table: "Receipt");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountRoll");

            migrationBuilder.DropIndex(
                name: "IX_Receipt_AccountId",
                table: "Receipt");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AccountId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_AccountId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "CartItem");
        }
    }
}
