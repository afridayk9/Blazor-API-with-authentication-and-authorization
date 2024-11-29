using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TfdThreeTier.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedCharacterPatternRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialDropChance",
                table: "Patterns");

            migrationBuilder.CreateTable(
                name: "CharacterPatterns",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    PatternId = table.Column<int>(type: "int", nullable: false),
                    MaterialDropChance = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterPatterns", x => new { x.CharacterId, x.PatternId });
                    table.ForeignKey(
                        name: "FK_CharacterPatterns_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterPatterns_Patterns_PatternId",
                        column: x => x.PatternId,
                        principalTable: "Patterns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterPatterns_PatternId",
                table: "CharacterPatterns",
                column: "PatternId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterPatterns");

            migrationBuilder.AddColumn<string>(
                name: "MaterialDropChance",
                table: "Patterns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
