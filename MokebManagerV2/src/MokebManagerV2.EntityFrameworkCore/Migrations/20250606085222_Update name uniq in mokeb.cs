using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MokebManagerV2.Migrations
{
    /// <inheritdoc />
    public partial class Updatenameuniqinmokeb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppMokeb_Name",
                table: "AppMokeb");

            migrationBuilder.CreateIndex(
                name: "IX_AppMokeb_Name",
                table: "AppMokeb",
                column: "Name",
                unique: true,
                filter: "[IsDeleted] = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppMokeb_Name",
                table: "AppMokeb");

            migrationBuilder.CreateIndex(
                name: "IX_AppMokeb_Name",
                table: "AppMokeb",
                column: "Name",
                unique: true);
        }
    }
}
