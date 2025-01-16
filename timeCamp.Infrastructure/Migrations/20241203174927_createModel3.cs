using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace timeCamp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createModel3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTicket");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Ticket",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_EmployeeId",
                table: "Ticket",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Employees_EmployeeId",
                table: "Ticket",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Employees_EmployeeId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_EmployeeId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Ticket");

            migrationBuilder.CreateTable(
                name: "EmployeeTicket",
                columns: table => new
                {
                    EmployeesId = table.Column<Guid>(type: "uuid", nullable: false),
                    TicketsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTicket", x => new { x.EmployeesId, x.TicketsId });
                    table.ForeignKey(
                        name: "FK_EmployeeTicket_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTicket_Ticket_TicketsId",
                        column: x => x.TicketsId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTicket_TicketsId",
                table: "EmployeeTicket",
                column: "TicketsId");
        }
    }
}
