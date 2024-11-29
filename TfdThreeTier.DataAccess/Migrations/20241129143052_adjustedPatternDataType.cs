using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TfdThreeTier.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class adjustedPatternDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MaterialDropChance",
                table: "Patterns",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MaterialDropChance",
                table: "Patterns",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
