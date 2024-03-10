using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace timeCamp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateddbtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeJob");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Job",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Job_EmployeeId",
                table: "Job",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Employees_EmployeeId",
                table: "Job",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Employees_EmployeeId",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_EmployeeId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Job");

            migrationBuilder.CreateTable(
                name: "EmployeeJob",
                columns: table => new
                {
                    EmployeesId = table.Column<Guid>(type: "uuid", nullable: false),
                    JobId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeJob", x => new { x.EmployeesId, x.JobId });
                    table.ForeignKey(
                        name: "FK_EmployeeJob_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeJob_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJob_JobId",
                table: "EmployeeJob",
                column: "JobId");
        }
    }
}
