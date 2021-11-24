using Microsoft.EntityFrameworkCore.Migrations;

namespace SEP3_DB_Server.Migrations
{
    public partial class _8_MicroDatabaseChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseItemLocationsDB_Locations_LocationId",
                table: "WarehouseItemLocationsDB");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseItemLocationsDB_WarehouseItems_ItemId",
                table: "WarehouseItemLocationsDB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarehouseItems",
                table: "WarehouseItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarehouseItemLocationsDB",
                table: "WarehouseItemLocationsDB");

            migrationBuilder.RenameTable(
                name: "WarehouseItems",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "WarehouseItemLocationsDB",
                newName: "ItemLocationsDB");

            migrationBuilder.RenameIndex(
                name: "IX_WarehouseItemLocationsDB_LocationId",
                table: "ItemLocationsDB",
                newName: "IX_ItemLocationsDB_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemLocationsDB",
                table: "ItemLocationsDB",
                columns: new[] { "ItemId", "LocationId" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemLocationsDB_Items_ItemId",
                table: "ItemLocationsDB");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemLocationsDB_Locations_LocationId",
                table: "ItemLocationsDB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemLocationsDB",
                table: "ItemLocationsDB");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "WarehouseItems");

            migrationBuilder.RenameTable(
                name: "ItemLocationsDB",
                newName: "WarehouseItemLocationsDB");

            migrationBuilder.RenameIndex(
                name: "IX_ItemLocationsDB_LocationId",
                table: "WarehouseItemLocationsDB",
                newName: "IX_WarehouseItemLocationsDB_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarehouseItems",
                table: "WarehouseItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarehouseItemLocationsDB",
                table: "WarehouseItemLocationsDB",
                columns: new[] { "ItemId", "LocationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseItemLocationsDB_Locations_LocationId",
                table: "WarehouseItemLocationsDB",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseItemLocationsDB_WarehouseItems_ItemId",
                table: "WarehouseItemLocationsDB",
                column: "ItemId",
                principalTable: "WarehouseItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
