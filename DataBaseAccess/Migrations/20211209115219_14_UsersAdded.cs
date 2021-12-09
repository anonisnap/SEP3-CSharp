using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataBaseAccess.Migrations
{
    public partial class _14_UsersAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntry_Items_ItemId1",
                table: "OrderEntry");

            migrationBuilder.DropIndex(
                name: "IX_OrderEntry_ItemId_OrderId",
                table: "OrderEntry");

            migrationBuilder.DropIndex(
                name: "IX_OrderEntry_ItemId1",
                table: "OrderEntry");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "OrderEntry");

            migrationBuilder.DropColumn(
                name: "ItemId1",
                table: "OrderEntry");

            migrationBuilder.CreateTable(
                name: "OrderEntriesDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntriesDbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    SecurityLevel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntry_ItemId",
                table: "OrderEntry",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntriesDbs_Id_OrderId",
                table: "OrderEntriesDbs",
                columns: new[] { "Id", "OrderId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntry_Items_ItemId",
                table: "OrderEntry",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntry_Items_ItemId",
                table: "OrderEntry");

            migrationBuilder.DropTable(
                name: "OrderEntriesDbs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_OrderEntry_ItemId",
                table: "OrderEntry");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "OrderEntry",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ItemId1",
                table: "OrderEntry",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntry_ItemId_OrderId",
                table: "OrderEntry",
                columns: new[] { "ItemId", "OrderId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntry_ItemId1",
                table: "OrderEntry",
                column: "ItemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntry_Items_ItemId1",
                table: "OrderEntry",
                column: "ItemId1",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
