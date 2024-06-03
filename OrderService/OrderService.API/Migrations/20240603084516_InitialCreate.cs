using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderService.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderModels",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderModels", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentModel",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    OrderModelOrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentModel", x => x.EquipmentId);
                    table.ForeignKey(
                        name: "FK_EquipmentModel_OrderModels_OrderModelOrderId",
                        column: x => x.OrderModelOrderId,
                        principalTable: "OrderModels",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentModel_Name",
                table: "EquipmentModel",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentModel_OrderModelOrderId",
                table: "EquipmentModel",
                column: "OrderModelOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentModel");

            migrationBuilder.DropTable(
                name: "OrderModels");
        }
    }
}
