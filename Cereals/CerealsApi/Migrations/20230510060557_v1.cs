using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CerealsApi.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_Cereals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cerealName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cerealCalorie = table.Column<int>(type: "int", nullable: false),
                    cerealProtein = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Cereals", x => x.Id);
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
