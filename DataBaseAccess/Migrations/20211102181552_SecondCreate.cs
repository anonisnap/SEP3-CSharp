using Microsoft.EntityFrameworkCore.Migrations;

namespace SEP3_DB_Server.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Snors");

            migrationBuilder.CreateTable(
                name: "Spikes",
                columns: table => new
                {
                    snor = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spikes", x => x.snor);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spikes");

            migrationBuilder.CreateTable(
                name: "Snors",
                columns: table => new
                {
                    snor = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snors", x => x.snor);
                });
        }
    }
}
