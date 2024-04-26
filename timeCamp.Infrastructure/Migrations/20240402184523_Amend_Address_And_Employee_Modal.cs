using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace timeCamp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AmendAddressAndEmployeeModal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "isDeleted",
                table: "Employees",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isEmployeeActive",
                table: "Employees",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "isEmployeeActive",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Addresses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Addresses",
                type: "text",
                nullable: true);
        }
    }
}
