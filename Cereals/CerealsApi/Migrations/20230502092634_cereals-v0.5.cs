using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CerealsApi.Migrations
{
    /// <inheritdoc />
    public partial class cerealsv05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cerialName",
                table: "TBL_Cereals",
                newName: "cerealName");

            migrationBuilder.RenameColumn(
                name: "cerialCalorie",
                table: "TBL_Cereals",
                newName: "cerealCalorie");

            migrationBuilder.AddColumn<int>(
                name: "cerealProtein",
                table: "TBL_Cereals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cerealProtein",
                table: "TBL_Cereals");

            migrationBuilder.RenameColumn(
                name: "cerealName",
                table: "TBL_Cereals",
                newName: "cerialName");

            migrationBuilder.RenameColumn(
                name: "cerealCalorie",
                table: "TBL_Cereals",
                newName: "cerialCalorie");
        }
    }
}
