using Microsoft.EntityFrameworkCore.Migrations;

namespace SEP3_DB_Server.Migrations
{
    public partial class postgrestestmigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpikeName",
                table: "Spikes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpikeName",
                table: "Spikes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
