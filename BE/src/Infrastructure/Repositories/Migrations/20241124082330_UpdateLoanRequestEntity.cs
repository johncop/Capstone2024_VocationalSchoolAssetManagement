using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLoanRequestEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_LoanerRequests_LoanerRequestId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_LoanerRequests_LoanerRequestId",
                table: "Notifications");

            migrationBuilder.DropTable(
                name: "LoanerRequestDetails");

            migrationBuilder.DropTable(
                name: "LoanerRequests");

            migrationBuilder.RenameColumn(
                name: "LoanerRequestId",
                table: "Notifications",
                newName: "LoanRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_LoanerRequestId",
                table: "Notifications",
                newName: "IX_Notifications_LoanRequestId");

            migrationBuilder.AddColumn<int>(
                name: "LoanRequestId",
                table: "Approvals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LoanRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    RequesterId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanRequests_AspNetUsers_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanRequestDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanerRequestId = table.Column<int>(type: "int", nullable: false),
                    LoanRequestId = table.Column<int>(type: "int", nullable: true),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConditionOnReturn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRequestDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanRequestDetails_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanRequestDetails_LoanRequests_LoanRequestId",
                        column: x => x.LoanRequestId,
                        principalTable: "LoanRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoanRequestDetailImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanRequestDetailId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRequestDetailImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanRequestDetailImage_LoanRequestDetails_LoanRequestDetailId",
                        column: x => x.LoanRequestDetailId,
                        principalTable: "LoanRequestDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_LoanRequestId",
                table: "Approvals",
                column: "LoanRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestDetailImage_LoanRequestDetailId",
                table: "LoanRequestDetailImage",
                column: "LoanRequestDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestDetails_AssetId",
                table: "LoanRequestDetails",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestDetails_LoanRequestId",
                table: "LoanRequestDetails",
                column: "LoanRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequests_RequesterId",
                table: "LoanRequests",
                column: "RequesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_LoanRequests_LoanRequestId",
                table: "Approvals",
                column: "LoanRequestId",
                principalTable: "LoanRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_LoanRequests_LoanRequestId",
                table: "Notifications",
                column: "LoanRequestId",
                principalTable: "LoanRequests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_LoanRequests_LoanRequestId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_LoanRequests_LoanRequestId",
                table: "Notifications");

            migrationBuilder.DropTable(
                name: "LoanRequestDetailImage");

            migrationBuilder.DropTable(
                name: "LoanRequestDetails");

            migrationBuilder.DropTable(
                name: "LoanRequests");

            migrationBuilder.DropIndex(
                name: "IX_Approvals_LoanRequestId",
                table: "Approvals");

            migrationBuilder.DropColumn(
                name: "LoanRequestId",
                table: "Approvals");

            migrationBuilder.RenameColumn(
                name: "LoanRequestId",
                table: "Notifications",
                newName: "LoanerRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_LoanRequestId",
                table: "Notifications",
                newName: "IX_Notifications_LoanerRequestId");

            migrationBuilder.CreateTable(
                name: "LoanerRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequesterId = table.Column<int>(type: "int", nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsApproved = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanerRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanerRequests_AspNetUsers_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanerRequestDetails",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    LoanerRequestId = table.Column<int>(type: "int", nullable: false),
                    ConditionOnReturn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanerRequestDetails", x => new { x.AssetId, x.LoanerRequestId });
                    table.ForeignKey(
                        name: "FK_LoanerRequestDetails_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanerRequestDetails_LoanerRequests_LoanerRequestId",
                        column: x => x.LoanerRequestId,
                        principalTable: "LoanerRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanerRequestDetails_LoanerRequestId",
                table: "LoanerRequestDetails",
                column: "LoanerRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanerRequests_RequesterId",
                table: "LoanerRequests",
                column: "RequesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_LoanerRequests_LoanerRequestId",
                table: "Approvals",
                column: "LoanerRequestId",
                principalTable: "LoanerRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_LoanerRequests_LoanerRequestId",
                table: "Notifications",
                column: "LoanerRequestId",
                principalTable: "LoanerRequests",
                principalColumn: "Id");
        }
    }
}
