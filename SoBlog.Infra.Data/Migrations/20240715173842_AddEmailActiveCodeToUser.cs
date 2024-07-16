using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoBlog.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailActiveCodeToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailActiveCode",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailActiveCode",
                table: "Users");
        }
    }
}
