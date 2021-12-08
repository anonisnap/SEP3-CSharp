using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataBaseAccess.Migrations
{
    public partial class _13_OrderEntryDBSetAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntries_Orders_OrderId",
                table: "OrderEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderEntries",
                table: "OrderEntries");

            migrationBuilder.RenameTable(
                name: "OrderEntries",
                newName: "OrderEntry");

            migrationBuilder.RenameIndex(
                name: "IX_OrderEntries_OrderId",
                table: "OrderEntry",
                newName: "IX_OrderEntry_OrderId");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "OrderEntry",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderEntry",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderEntry",
                table: "OrderEntry",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntry_Orders_OrderId",
                table: "OrderEntry",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntry_Items_ItemId1",
                table: "OrderEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntry_Orders_OrderId",
                table: "OrderEntry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderEntry",
                table: "OrderEntry");

            migrationBuilder.DropIndex(
                name: "IX_OrderEntry_ItemId_OrderId",
                table: "OrderEntry");

            migrationBuilder.DropIndex(
                name: "IX_OrderEntry_ItemId1",
                table: "OrderEntry");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderEntry");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "OrderEntry");

            migrationBuilder.DropColumn(
                name: "ItemId1",
                table: "OrderEntry");

            migrationBuilder.RenameTable(
                name: "OrderEntry",
                newName: "OrderEntries");

            migrationBuilder.RenameIndex(
                name: "IX_OrderEntry_OrderId",
                table: "OrderEntries",
                newName: "IX_OrderEntries_OrderId");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "OrderEntries",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderEntries",
                table: "OrderEntries",
                columns: new[] { "ItemId", "OrderId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntries_Orders_OrderId",
                table: "OrderEntries",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
