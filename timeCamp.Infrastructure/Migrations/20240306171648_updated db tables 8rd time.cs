﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace timeCamp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateddbtables8rdtime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Employees_EmployeeId",
                table: "Job");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "Job",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Employees_EmployeeId",
                table: "Job",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Employees_EmployeeId",
                table: "Job");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "Job",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Employees_EmployeeId",
                table: "Job",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
