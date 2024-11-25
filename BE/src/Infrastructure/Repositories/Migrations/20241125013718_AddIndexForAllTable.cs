using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexForAllTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Notifications_Id",
                table: "Notifications",
                column: "Id",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_Id",
                table: "Maintenances",
                column: "Id",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceImages_Id",
                table: "MaintenanceImages",
                column: "Id",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequests_Id",
                table: "LoanRequests",
                column: "Id",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestDetails_Id",
                table: "LoanRequestDetails",
                column: "Id",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestDetailImage_Id",
                table: "LoanRequestDetailImage",
                column: "Id",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Depreciations_Id",
                table: "Depreciations",
                column: "Id",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_DepreciationImages_Id",
                table: "DepreciationImages",
                column: "Id",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Id",
                table: "Categories",
                column: "Id",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_AssetTypes_Id",
                table: "AssetTypes",
                column: "Id",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_AssetTransactions_Id",
                table: "AssetTransactions",
                column: "Id",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Id",
                table: "Assets",
                column: "Id",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_AssetImages_Id",
                table: "AssetImages",
                column: "Id",
                descending: new bool[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Notifications_Id",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Maintenances_Id",
                table: "Maintenances");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceImages_Id",
                table: "MaintenanceImages");

            migrationBuilder.DropIndex(
                name: "IX_LoanRequests_Id",
                table: "LoanRequests");

            migrationBuilder.DropIndex(
                name: "IX_LoanRequestDetails_Id",
                table: "LoanRequestDetails");

            migrationBuilder.DropIndex(
                name: "IX_LoanRequestDetailImage_Id",
                table: "LoanRequestDetailImage");

            migrationBuilder.DropIndex(
                name: "IX_Depreciations_Id",
                table: "Depreciations");

            migrationBuilder.DropIndex(
                name: "IX_DepreciationImages_Id",
                table: "DepreciationImages");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Id",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_AssetTypes_Id",
                table: "AssetTypes");

            migrationBuilder.DropIndex(
                name: "IX_AssetTransactions_Id",
                table: "AssetTransactions");

            migrationBuilder.DropIndex(
                name: "IX_Assets_Id",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_AssetImages_Id",
                table: "AssetImages");
        }
    }
}
