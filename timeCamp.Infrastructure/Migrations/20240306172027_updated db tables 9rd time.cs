using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace timeCamp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateddbtables9rdtime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "JobId",
                table: "Employees",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobId",
                table: "Employees",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Job_JobId",
                table: "Employees",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Job_JobId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_JobId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Employees");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Job",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Job_EmployeeId",
                table: "Job",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Employees_EmployeeId",
                table: "Job",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
