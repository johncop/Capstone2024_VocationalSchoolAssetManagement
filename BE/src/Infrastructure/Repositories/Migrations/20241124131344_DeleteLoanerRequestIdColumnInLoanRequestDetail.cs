using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM.Database.Migrations
{
    /// <inheritdoc />
    public partial class DeleteLoanerRequestIdColumnInLoanRequestDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanRequestDetails_LoanRequests_LoanRequestId",
                table: "LoanRequestDetails");

            migrationBuilder.DropColumn(
                name: "LoanerRequestId",
                table: "LoanRequestDetails");

            migrationBuilder.AlterColumn<int>(
                name: "LoanRequestId",
                table: "LoanRequestDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanRequestDetails_LoanRequests_LoanRequestId",
                table: "LoanRequestDetails",
                column: "LoanRequestId",
                principalTable: "LoanRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanRequestDetails_LoanRequests_LoanRequestId",
                table: "LoanRequestDetails");

            migrationBuilder.AlterColumn<int>(
                name: "LoanRequestId",
                table: "LoanRequestDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LoanerRequestId",
                table: "LoanRequestDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanRequestDetails_LoanRequests_LoanRequestId",
                table: "LoanRequestDetails",
                column: "LoanRequestId",
                principalTable: "LoanRequests",
                principalColumn: "Id");
        }
    }
}
