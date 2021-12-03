using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseAccess.Migrations.TestDb
{
    public partial class _4_updatedItemLocationDb : Migration
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

            migrationBuilder.RenameTable(
                name: "ItemLocationsDB",
                newName: "ItemLocationsDb");

            migrationBuilder.RenameIndex(
                name: "IX_ItemLocationsDB_LocationId",
                table: "ItemLocationsDb",
                newName: "IX_ItemLocationsDb_LocationId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ItemLocationsDb",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemLocationsDb",
                table: "ItemLocationsDb",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemLocationsDb_ItemId_LocationId",
                table: "ItemLocationsDb",
                columns: new[] { "ItemId", "LocationId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemLocationsDb_Items_ItemId",
                table: "ItemLocationsDb",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemLocationsDb_Locations_LocationId",
                table: "ItemLocationsDb",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemLocationsDb_Items_ItemId",
                table: "ItemLocationsDb");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemLocationsDb_Locations_LocationId",
                table: "ItemLocationsDb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemLocationsDb",
                table: "ItemLocationsDb");

            migrationBuilder.DropIndex(
                name: "IX_ItemLocationsDb_ItemId_LocationId",
                table: "ItemLocationsDb");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ItemLocationsDb");

            migrationBuilder.RenameTable(
                name: "ItemLocationsDb",
                newName: "ItemLocationsDB");

            migrationBuilder.RenameIndex(
                name: "IX_ItemLocationsDb_LocationId",
                table: "ItemLocationsDB",
                newName: "IX_ItemLocationsDB_LocationId");

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
    }
}
