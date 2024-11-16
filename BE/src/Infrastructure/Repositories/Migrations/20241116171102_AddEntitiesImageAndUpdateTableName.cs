using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddEntitiesImageAndUpdateTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maintainces");

            migrationBuilder.AddColumn<int>(
                name: "LoanerRequestId",
                table: "Notifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepreciationId",
                table: "Depreciations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AssetImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetImages_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetTransactions_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepreciationImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepreciationId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepreciationImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepreciationImages_Depreciations_DepreciationId",
                        column: x => x.DepreciationId,
                        principalTable: "Depreciations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenances_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaintenanceId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceImages_Maintenances_MaintenanceId",
                        column: x => x.MaintenanceId,
                        principalTable: "Maintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_LoanerRequestId",
                table: "Notifications",
                column: "LoanerRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Depreciations_DepreciationId",
                table: "Depreciations",
                column: "DepreciationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetImages_AssetId",
                table: "AssetImages",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetTransactions_AssetId",
                table: "AssetTransactions",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_DepreciationImages_DepreciationId",
                table: "DepreciationImages",
                column: "DepreciationId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceImages_MaintenanceId",
                table: "MaintenanceImages",
                column: "MaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_AssetId",
                table: "Maintenances",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depreciations_Depreciations_DepreciationId",
                table: "Depreciations",
                column: "DepreciationId",
                principalTable: "Depreciations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_LoanerRequests_LoanerRequestId",
                table: "Notifications",
                column: "LoanerRequestId",
                principalTable: "LoanerRequests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depreciations_Depreciations_DepreciationId",
                table: "Depreciations");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_LoanerRequests_LoanerRequestId",
                table: "Notifications");

            migrationBuilder.DropTable(
                name: "AssetImages");

            migrationBuilder.DropTable(
                name: "AssetTransactions");

            migrationBuilder.DropTable(
                name: "DepreciationImages");

            migrationBuilder.DropTable(
                name: "MaintenanceImages");

            migrationBuilder.DropTable(
                name: "Maintenances");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_LoanerRequestId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Depreciations_DepreciationId",
                table: "Depreciations");

            migrationBuilder.DropColumn(
                name: "LoanerRequestId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "DepreciationId",
                table: "Depreciations");

            migrationBuilder.CreateTable(
                name: "Maintainces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MaintainceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintainces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintainces_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maintainces_AssetId",
                table: "Maintainces",
                column: "AssetId");
        }
    }
}
