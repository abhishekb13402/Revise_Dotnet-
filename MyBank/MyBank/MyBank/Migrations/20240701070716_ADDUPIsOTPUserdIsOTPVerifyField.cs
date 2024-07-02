using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBank.Migrations
{
    /// <inheritdoc />
    public partial class ADDUPIsOTPUserdIsOTPVerifyField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsUsed",
                table: "Account",
                newName: "IsOTPVerify");

            migrationBuilder.AddColumn<bool>(
                name: "IsOTPUsed",
                table: "Account",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOTPUsed",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "IsOTPVerify",
                table: "Account",
                newName: "IsUsed");
        }
    }
}
