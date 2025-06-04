using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MokebManagerV2.Migrations
{
    /// <inheritdoc />
    public partial class InitMokebsexpilgrimmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppMokeb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMokeb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppPilgrim",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PassportNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    BedNumber = table.Column<int>(type: "int", nullable: false),
                    MokebId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ForceExitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Traffic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPilgrim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppPilgrim_AppMokeb_MokebId",
                        column: x => x.MokebId,
                        principalTable: "AppMokeb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppMokeb_Name",
                table: "AppMokeb",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppPilgrim_MokebId",
                table: "AppPilgrim",
                column: "MokebId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPilgrim_NationalCode",
                table: "AppPilgrim",
                column: "NationalCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppPilgrim_PassportNo",
                table: "AppPilgrim",
                column: "PassportNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppPilgrim_PhoneNumber",
                table: "AppPilgrim",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppPilgrim");

            migrationBuilder.DropTable(
                name: "AppMokeb");
        }
    }
}
