using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPEntityBank.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    transactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    transactionCompteDebit = table.Column<long>(type: "bigint", nullable: false),
                    transactionCompteCredit = table.Column<long>(type: "bigint", nullable: false),
                    transactionMontant = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.transactionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions");
        }
    }
}
