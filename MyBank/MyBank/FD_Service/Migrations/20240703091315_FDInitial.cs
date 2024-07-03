using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FD_Service.Migrations
{
    /// <inheritdoc />
    public partial class FDInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FDDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FDPlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<double>(type: "float", nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FDDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerFDDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Plan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MaturityAmount = table.Column<double>(type: "float", nullable: false),
                    FDDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFDDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerFDDetails_FDDetails_FDDetailsId",
                        column: x => x.FDDetailsId,
                        principalTable: "FDDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFDDetails_FDDetailsId",
                table: "CustomerFDDetails",
                column: "FDDetailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerFDDetails");

            migrationBuilder.DropTable(
                name: "FDDetails");
        }
    }
}
