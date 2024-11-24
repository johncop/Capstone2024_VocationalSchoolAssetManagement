using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApprovalTableRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Approvals",
                table: "Approvals");

            migrationBuilder.DropIndex(
                name: "IX_Approvals_LoanRequestId",
                table: "Approvals");

            migrationBuilder.DropColumn(
                name: "LoanerRequestId",
                table: "Approvals");

            migrationBuilder.AlterColumn<int>(
                name: "LoanRequestId",
                table: "Approvals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Approvals",
                table: "Approvals",
                columns: new[] { "LoanRequestId", "ApproverId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Approvals",
                table: "Approvals");

            migrationBuilder.AlterColumn<int>(
                name: "LoanRequestId",
                table: "Approvals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LoanerRequestId",
                table: "Approvals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Approvals",
                table: "Approvals",
                columns: new[] { "LoanerRequestId", "ApproverId" });

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_LoanRequestId",
                table: "Approvals",
                column: "LoanRequestId");
        }
    }
}
