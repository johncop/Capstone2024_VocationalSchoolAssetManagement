using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLoanRequestToRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "LoanRequestId",
                table: "Notifications",
                newName: "RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_LoanRequestId",
                table: "Notifications",
                newName: "IX_Notifications_RequestId");

            migrationBuilder.RenameColumn(
                name: "LoanRequestId",
                table: "Approvals",
                newName: "RequestId");

            migrationBuilder.CreateTable(
                name: "Requests",
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
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_RequestDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestDetails_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestDetails_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestDetailImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDetailId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDetailImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestDetailImage_RequestDetails_RequestDetailId",
                        column: x => x.RequestDetailId,
                        principalTable: "RequestDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestDetailImage_Id",
                table: "RequestDetailImage",
                column: "Id",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_RequestDetailImage_RequestDetailId",
                table: "RequestDetailImage",
                column: "RequestDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDetails_AssetId",
                table: "RequestDetails",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDetails_Id",
                table: "RequestDetails",
                column: "Id",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_RequestDetails_RequestId",
                table: "RequestDetails",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_Id",
                table: "Requests",
                column: "Id",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequesterId",
                table: "Requests",
                column: "RequesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_Requests_RequestId",
                table: "Approvals",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Requests_RequestId",
                table: "Notifications",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_Requests_RequestId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Requests_RequestId",
                table: "Notifications");

            migrationBuilder.DropTable(
                name: "RequestDetailImage");

            migrationBuilder.DropTable(
                name: "RequestDetails");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "Notifications",
                newName: "LoanRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_RequestId",
                table: "Notifications",
                newName: "IX_Notifications_LoanRequestId");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "Approvals",
                newName: "LoanRequestId");

            migrationBuilder.CreateTable(
                name: "LoanRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequesterId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    LoanRequestId = table.Column<int>(type: "int", nullable: false),
                    ActualReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConditionOnReturn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanRequestDetailImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanRequestDetailId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "IX_LoanRequestDetailImage_Id",
                table: "LoanRequestDetailImage",
                column: "Id",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestDetailImage_LoanRequestDetailId",
                table: "LoanRequestDetailImage",
                column: "LoanRequestDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestDetails_AssetId",
                table: "LoanRequestDetails",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestDetails_Id",
                table: "LoanRequestDetails",
                column: "Id",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestDetails_LoanRequestId",
                table: "LoanRequestDetails",
                column: "LoanRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequests_Id",
                table: "LoanRequests",
                column: "Id",
                descending: new bool[0]);

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
    }
}
