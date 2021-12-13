using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataBaseAccess.Migrations
{
    public partial class _20_AddedIsCompletetToOrderEntryDbRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderEntriesDbs");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "OrderEntry",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "OrderEntry");

            migrationBuilder.CreateTable(
                name: "OrderEntriesDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntriesDbs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntriesDbs_Id_OrderId",
                table: "OrderEntriesDbs",
                columns: new[] { "Id", "OrderId" },
                unique: true);
        }
    }
}
