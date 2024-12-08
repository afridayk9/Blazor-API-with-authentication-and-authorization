using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TfdThreeTier.DataAccess.Migrations.UserDb
{
    /// <inheritdoc />
    public partial class fixedRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens");

            migrationBuilder.RenameTable(
                name: "RefreshTokens",
                newName: "RefreshTokenInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokenInfo",
                table: "RefreshTokenInfo",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokenInfo",
                table: "RefreshTokenInfo");

            migrationBuilder.RenameTable(
                name: "RefreshTokenInfo",
                newName: "RefreshTokens");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens",
                column: "Id");
        }
    }
}
