using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MokebManagerV2.Migrations
{
    /// <inheritdoc />
    public partial class AddFreeCapacityMokeb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FreeCapacity",
                table: "AppMokeb",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FreeCapacity",
                table: "AppMokeb");
        }
    }
}
