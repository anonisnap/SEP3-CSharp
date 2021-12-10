using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseAccess.Migrations
{
    public partial class _17_DeleteItemLocationDataSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {   
            migrationBuilder.DropTable(
                name: "ItemLocations");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            
        }
    }
}
