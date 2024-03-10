using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace timeCamp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addcredentialstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeCredentialsId",
                table: "Employees",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "EmployeeCredentials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCredentials", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeCredentialsId",
                table: "Employees",
                column: "EmployeeCredentialsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeCredentials_EmployeeCredentialsId",
                table: "Employees",
                column: "EmployeeCredentialsId",
                principalTable: "EmployeeCredentials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeCredentials_EmployeeCredentialsId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeCredentials");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeCredentialsId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeCredentialsId",
                table: "Employees");
        }
    }
}
