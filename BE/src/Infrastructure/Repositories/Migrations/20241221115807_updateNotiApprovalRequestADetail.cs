using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM.Database.Migrations
{
    /// <inheritdoc />
    public partial class updateNotiApprovalRequestADetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_AspNetUsers_ApproverId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Requests_RequestId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Approvals_ApproverId",
                table: "Approvals");

            migrationBuilder.DropColumn(
                name: "ActualDate",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ReceivedDate",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ExpiredAt",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "RequestDetails",
                newName: "AssetNewLocationId");

            migrationBuilder.RenameColumn(
                name: "ConditionOnReturn",
                table: "RequestDetails",
                newName: "AssetOldLocation");

            migrationBuilder.RenameColumn(
                name: "ApprovalStatus",
                table: "Approvals",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Requests",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewLocationId",
                table: "RequestDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceivedDate",
                table: "RequestDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SerialNumber",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Assets",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QrCodeUrl",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestDetails_NewLocationId",
                table: "RequestDetails",
                column: "NewLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_UserId",
                table: "Approvals",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_AspNetUsers_UserId",
                table: "Approvals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Requests_RequestId",
                table: "Notifications",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDetails_Locations_NewLocationId",
                table: "RequestDetails",
                column: "NewLocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_AspNetUsers_UserId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Requests_RequestId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestDetails_Locations_NewLocationId",
                table: "RequestDetails");

            migrationBuilder.DropIndex(
                name: "IX_RequestDetails_NewLocationId",
                table: "RequestDetails");

            migrationBuilder.DropIndex(
                name: "IX_Approvals_UserId",
                table: "Approvals");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "NewLocationId",
                table: "RequestDetails");

            migrationBuilder.DropColumn(
                name: "ReceivedDate",
                table: "RequestDetails");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "QrCodeUrl",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "AssetOldLocation",
                table: "RequestDetails",
                newName: "ConditionOnReturn");

            migrationBuilder.RenameColumn(
                name: "AssetNewLocationId",
                table: "RequestDetails",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Approvals",
                newName: "ApprovalStatus");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualDate",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Requests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceivedDate",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "Notifications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredAt",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Notifications",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Notifications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SerialNumber",
                table: "Assets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "Assets",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_ApproverId",
                table: "Approvals",
                column: "ApproverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_AspNetUsers_ApproverId",
                table: "Approvals",
                column: "ApproverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Requests_RequestId",
                table: "Notifications",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id");
        }
    }
}
