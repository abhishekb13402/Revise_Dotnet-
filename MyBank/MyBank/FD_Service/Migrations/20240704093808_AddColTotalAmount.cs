using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FD_Service.Migrations
{
    /// <inheritdoc />
    public partial class AddColTotalAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalAmount",
                table: "CustomerFDDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "CustomerFDDetails");
        }
    }
}
