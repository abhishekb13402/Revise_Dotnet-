using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice.Migrations
{
    /// <inheritdoc />
    public partial class UPEmailTypeInEmployeeAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeeAuths_employees_EmployeeEmail",
                table: "employeeAuths");

            migrationBuilder.DropIndex(
                name: "IX_employeeAuths_EmployeeEmail",
                table: "employeeAuths");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeEmail",
                table: "employees",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeEmail",
                table: "employeeAuths",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_employees_EmployeeEmail",
                table: "employees",
                column: "EmployeeEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employeeAuths_EmployeeId",
                table: "employeeAuths",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_employeeAuths_employees_EmployeeId",
                table: "employeeAuths",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeeAuths_employees_EmployeeId",
                table: "employeeAuths");

            migrationBuilder.DropIndex(
                name: "IX_employees_EmployeeEmail",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employeeAuths_EmployeeId",
                table: "employeeAuths");

            migrationBuilder.DropColumn(
                name: "EmployeeEmail",
                table: "employees");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeEmail",
                table: "employeeAuths",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_employeeAuths_EmployeeEmail",
                table: "employeeAuths",
                column: "EmployeeEmail",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_employeeAuths_employees_EmployeeEmail",
                table: "employeeAuths",
                column: "EmployeeEmail",
                principalTable: "employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
