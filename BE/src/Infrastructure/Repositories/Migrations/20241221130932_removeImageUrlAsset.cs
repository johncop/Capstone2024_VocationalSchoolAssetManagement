using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM.Database.Migrations
{
    /// <inheritdoc />
    public partial class removeImageUrlAsset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Assets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
