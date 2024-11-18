using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNullableForAssetEntitty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Inventories_InventoryId",
                table: "Assets");

            migrationBuilder.AlterColumn<int>(
                name: "InventoryId",
                table: "Assets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Inventories_InventoryId",
                table: "Assets",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Inventories_InventoryId",
                table: "Assets");

            migrationBuilder.AlterColumn<int>(
                name: "InventoryId",
                table: "Assets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Inventories_InventoryId",
                table: "Assets",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
