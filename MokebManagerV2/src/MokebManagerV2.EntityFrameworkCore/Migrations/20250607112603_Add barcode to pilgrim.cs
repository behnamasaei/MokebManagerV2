using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MokebManagerV2.Migrations
{
    /// <inheritdoc />
    public partial class Addbarcodetopilgrim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "AppPilgrim",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "AppPilgrim");
        }
    }
}
