using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class sp2121addfluentapiconfigurationandrenamemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalariesData_Functions_FunctionIdId",
                table: "SalariesData");

            migrationBuilder.DropForeignKey(
                name: "FK_SalariesData_Regions_RegionIdId",
                table: "SalariesData");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleIdId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleIdId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_SalariesData_FunctionIdId",
                table: "SalariesData");

            migrationBuilder.DropIndex(
                name: "IX_SalariesData_RegionIdId",
                table: "SalariesData");

            migrationBuilder.DropColumn(
                name: "RoleIdId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FunctionIdId",
                table: "SalariesData");

            migrationBuilder.DropColumn(
                name: "MaxSalary",
                table: "SalariesData");

            migrationBuilder.DropColumn(
                name: "MinSalary",
                table: "SalariesData");

            migrationBuilder.DropColumn(
                name: "RegionIdId",
                table: "SalariesData");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "Function",
                table: "Functions");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FunctionId",
                table: "SalariesData",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Max",
                table: "SalariesData",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Min",
                table: "SalariesData",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "SalariesData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Roles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Regions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Functions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SalariesData_FunctionId",
                table: "SalariesData",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_SalariesData_RegionId",
                table: "SalariesData",
                column: "RegionId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalariesData_Functions_FunctionId",
                table: "SalariesData");

            migrationBuilder.DropForeignKey(
                name: "FK_SalariesData_Regions_RegionId",
                table: "SalariesData");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_SalariesData_FunctionId",
                table: "SalariesData");

            migrationBuilder.DropIndex(
                name: "IX_SalariesData_RegionId",
                table: "SalariesData");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FunctionId",
                table: "SalariesData");

            migrationBuilder.DropColumn(
                name: "Max",
                table: "SalariesData");

            migrationBuilder.DropColumn(
                name: "Min",
                table: "SalariesData");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "SalariesData");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Functions");

            migrationBuilder.AddColumn<int>(
                name: "RoleIdId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FunctionIdId",
                table: "SalariesData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxSalary",
                table: "SalariesData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinSalary",
                table: "SalariesData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegionIdId",
                table: "SalariesData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Function",
                table: "Functions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleIdId",
                table: "Users",
                column: "RoleIdId");

            migrationBuilder.CreateIndex(
                name: "IX_SalariesData_FunctionIdId",
                table: "SalariesData",
                column: "FunctionIdId");

            migrationBuilder.CreateIndex(
                name: "IX_SalariesData_RegionIdId",
                table: "SalariesData",
                column: "RegionIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalariesData_Functions_FunctionIdId",
                table: "SalariesData",
                column: "FunctionIdId",
                principalTable: "Functions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalariesData_Regions_RegionIdId",
                table: "SalariesData",
                column: "RegionIdId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleIdId",
                table: "Users",
                column: "RoleIdId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
