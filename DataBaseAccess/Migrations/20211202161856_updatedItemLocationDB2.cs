using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseAccess.Migrations
{
    public partial class updatedItemLocationDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ItemLocationsDb_LocationId",
                table: "ItemLocationsDb",
                column: "LocationId");

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

            migrationBuilder.DropIndex(
                name: "IX_ItemLocationsDb_LocationId",
                table: "ItemLocationsDb");
        }
    }
}
