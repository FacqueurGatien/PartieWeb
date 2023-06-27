using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sudokuData.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grille",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grille", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ligne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrilleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ligne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ligne_Grille_GrilleId",
                        column: x => x.GrilleId,
                        principalTable: "Grille",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Case",
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
                    table.PrimaryKey("PK_Case", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Case_Ligne_LigneId",
                        column: x => x.LigneId,
                        principalTable: "Ligne",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Case_LigneId",
                table: "Case",
                column: "LigneId");

            migrationBuilder.CreateIndex(
                name: "IX_Ligne_GrilleId",
                table: "Ligne",
                column: "GrilleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DropTable(
                name: "Ligne");

            migrationBuilder.DropTable(
                name: "Grille");
        }
    }
}
