using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CerealsApi.Migrations
{
    /// <inheritdoc />
    public partial class cerealsv0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_Cereals",
                columns: table => new
                {
                    cerealId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cerialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cerialCalorie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Cereals", x => x.cerealId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_Cereals");
        }
    }
}
