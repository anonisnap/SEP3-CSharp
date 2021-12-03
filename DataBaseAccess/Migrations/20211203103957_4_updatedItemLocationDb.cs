using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataBaseAccess.Migrations
{
    public partial class _4_updatedItemLocationDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemLocationsDb",
                table: "ItemLocationsDb");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ItemLocationsDb",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemLocationsDb",
                table: "ItemLocationsDb",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemLocationsDb_ItemId_LocationId",
                table: "ItemLocationsDb",
                columns: new[] { "ItemId", "LocationId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemLocationsDb",
                table: "ItemLocationsDb");

            migrationBuilder.DropIndex(
                name: "IX_ItemLocationsDb_ItemId_LocationId",
                table: "ItemLocationsDb");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ItemLocationsDb");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemLocationsDb",
                table: "ItemLocationsDb",
                columns: new[] { "ItemId", "LocationId" });
        }
    }
}
