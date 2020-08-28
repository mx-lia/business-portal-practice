using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class sp2123addfluentapiconfigurationandrenamemodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalariesData_Functions_FunctionId",
                table: "SalariesData");

            migrationBuilder.DropForeignKey(
                name: "FK_SalariesData_Regions_RegionId",
                table: "SalariesData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalariesData",
                table: "SalariesData");

            migrationBuilder.RenameTable(
                name: "SalariesData",
                newName: "Salaries");

            migrationBuilder.RenameIndex(
                name: "IX_SalariesData_RegionId",
                table: "Salaries",
                newName: "IX_Salaries_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_SalariesData_FunctionId",
                table: "Salaries",
                newName: "IX_Salaries_FunctionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salaries",
                table: "Salaries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Functions_FunctionId",
                table: "Salaries",
                column: "FunctionId",
                principalTable: "Functions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Regions_RegionId",
                table: "Salaries",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Functions_FunctionId",
                table: "Salaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Regions_RegionId",
                table: "Salaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salaries",
                table: "Salaries");

            migrationBuilder.RenameTable(
                name: "Salaries",
                newName: "SalariesData");

            migrationBuilder.RenameIndex(
                name: "IX_Salaries_RegionId",
                table: "SalariesData",
                newName: "IX_SalariesData_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Salaries_FunctionId",
                table: "SalariesData",
                newName: "IX_SalariesData_FunctionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalariesData",
                table: "SalariesData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalariesData_Functions_FunctionId",
                table: "SalariesData",
                column: "FunctionId",
                principalTable: "Functions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalariesData_Regions_RegionId",
                table: "SalariesData",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
