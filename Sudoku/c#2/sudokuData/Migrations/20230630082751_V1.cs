using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sudokuData.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "grilles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grilles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rangees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrilleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rangees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rangees_grilles_GrilleId",
                        column: x => x.GrilleId,
                        principalTable: "grilles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenu = table.Column<int>(type: "int", nullable: false),
                    Num_Rangee = table.Column<int>(type: "int", nullable: false),
                    Num_Colonne = table.Column<int>(type: "int", nullable: false),
                    Num_Block = table.Column<int>(type: "int", nullable: false),
                    LigneId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cases_rangees_LigneId",
                        column: x => x.LigneId,
                        principalTable: "rangees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cases_LigneId",
                table: "cases",
                column: "LigneId");

            migrationBuilder.CreateIndex(
                name: "IX_rangees_GrilleId",
                table: "rangees",
                column: "GrilleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cases");

            migrationBuilder.DropTable(
                name: "rangees");

            migrationBuilder.DropTable(
                name: "grilles");
        }
    }
}
