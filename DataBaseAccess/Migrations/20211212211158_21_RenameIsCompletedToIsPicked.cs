using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseAccess.Migrations
{
    public partial class _21_RenameIsCompletedToIsPicked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "IsCompleted",
            table: "OrderEntry");
            
            migrationBuilder.AddColumn<bool>(
                name: "IsPicked",
                table: "OrderEntry",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn(
                name: "IsPicked",
                table: "OrderEntry");
            
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "OrderEntry",
                type: "boolean",
                nullable: false,
                defaultValue: false);

        }
    }
}
