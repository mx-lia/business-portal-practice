using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class s2120changeenumiration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Role",
                keyValue: "1",
                column: "Role",
                value: "2");
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Role",
                keyValue: "0",
                column: "Role",
                value: "1");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
