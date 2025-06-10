using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MokebManagerV2.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Pilgrim_unique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppPilgrim_NationalCode",
                table: "AppPilgrim");

            migrationBuilder.DropIndex(
                name: "IX_AppPilgrim_PassportNo",
                table: "AppPilgrim");

            migrationBuilder.DropIndex(
                name: "IX_AppPilgrim_PhoneNumber",
                table: "AppPilgrim");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AppPilgrim_NationalCode",
                table: "AppPilgrim",
                column: "NationalCode",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_AppPilgrim_PassportNo",
                table: "AppPilgrim",
                column: "PassportNo",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_AppPilgrim_PhoneNumber",
                table: "AppPilgrim",
                column: "PhoneNumber",
                unique: true,
                filter: "[IsDeleted] = 0");
        }
    }
}
