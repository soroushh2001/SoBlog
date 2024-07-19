using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoBlog.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTagTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SystemTitle",
                table: "Tags");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SystemTitle",
                table: "Tags",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }
    }
}
