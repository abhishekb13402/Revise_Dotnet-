using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBank.Migrations
{
    /// <inheritdoc />
    public partial class AddOTPFieldsInAccounttbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryTime",
                table: "Account",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "Account",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OTPValue",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiryTime",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "OTPValue",
                table: "Account");
        }
    }
}
