using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace timeCamp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AmendAddressModal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Addresses",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Addresses");
        }
    }
}
