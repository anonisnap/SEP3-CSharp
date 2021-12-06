using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseAccess.Migrations
{
    public partial class updatedItemLocationDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemLocationsDB_Items_ItemId",
                table: "ItemLocationsDB");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemLocationsDB_Locations_LocationId",
                table: "ItemLocationsDB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemLocationsDB",
                table: "ItemLocationsDB");

            migrationBuilder.DropIndex(
                name: "IX_ItemLocationsDB_LocationId",
                table: "ItemLocationsDB");

            migrationBuilder.RenameTable(
                name: "ItemLocationsDB",
                newName: "ItemLocationsDb");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Locations",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Items",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemLocationsDb",
                table: "ItemLocationsDb",
                columns: new[] { "ItemId", "LocationId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemLocationsDb",
                table: "ItemLocationsDb");

            migrationBuilder.RenameTable(
                name: "ItemLocationsDb",
                newName: "ItemLocationsDB");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Locations",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Items",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemLocationsDB",
                table: "ItemLocationsDB",
                columns: new[] { "ItemId", "LocationId" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemLocationsDB_LocationId",
                table: "ItemLocationsDB",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemLocationsDB_Items_ItemId",
                table: "ItemLocationsDB",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemLocationsDB_Locations_LocationId",
                table: "ItemLocationsDB",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
