using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MokebManagerV2.Migrations
{
    /// <inheritdoc />
    public partial class AddBedmodelsanddtos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BedId",
                table: "AppPilgrim",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AppBed",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    PilgrimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBed", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppPilgrim_BedId",
                table: "AppPilgrim",
                column: "BedId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppPilgrim_AppBed_BedId",
                table: "AppPilgrim",
                column: "BedId",
                principalTable: "AppBed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPilgrim_AppBed_BedId",
                table: "AppPilgrim");

            migrationBuilder.DropTable(
                name: "AppBed");

            migrationBuilder.DropIndex(
                name: "IX_AppPilgrim_BedId",
                table: "AppPilgrim");

            migrationBuilder.DropColumn(
                name: "BedId",
                table: "AppPilgrim");
        }
    }
}
