using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoBlog.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAuhtorJobAndDescriptionToUserTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuhtorJob",
                table: "Users",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorDescription",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuhtorJob",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AuthorDescription",
                table: "Users");
        }
    }
}
