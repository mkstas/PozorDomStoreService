using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PozorDomStoreService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_device_configurations_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceSpecifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uuid", nullable: false),
                    SpecificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceSpecifications_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceSpecifications_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceSpecifications_DeviceId",
                table: "DeviceSpecifications",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceSpecifications_SpecificationId",
                table: "DeviceSpecifications",
                column: "SpecificationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceSpecifications");
        }
    }
}
