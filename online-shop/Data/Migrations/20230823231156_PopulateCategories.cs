using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace online_shop.Migrations
{
    /// <inheritdoc />
    public partial class PopulateCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO productcategory (Id, Category) VALUES (1,'Digital')");
            migrationBuilder.Sql("INSERT INTO productcategory (Id, Category) VALUES (2,'Food')");
            migrationBuilder.Sql("INSERT INTO productcategory (Id, Category) VALUES (3,'Stationery')");
            migrationBuilder.Sql("INSERT INTO productcategory (Id, Category) VALUES (4,'Vehicle')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
