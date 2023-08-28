using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace online_shop.Migrations
{
    /// <inheritdoc />
    public partial class PopulateCommentStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO commentstatus (Id, Status) VALUES (1,'Waiting')");
            migrationBuilder.Sql("INSERT INTO commentstatus (Id, Status) VALUES (2,'Accepted')");
            migrationBuilder.Sql("INSERT INTO commentstatus (Id, Status) VALUES (3,'Rejected')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
