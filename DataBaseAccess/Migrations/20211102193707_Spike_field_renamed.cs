using Microsoft.EntityFrameworkCore.Migrations;

namespace SEP3_DB_Server.Migrations
{
    public partial class Spike_field_renamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SnorName",
                table: "Spikes",
                newName: "SpikeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpikeName",
                table: "Spikes",
                newName: "SnorName");
        }
    }
}
