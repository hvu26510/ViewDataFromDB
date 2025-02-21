using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViewDataFromDB.Migrations
{
    /// <inheritdoc />
    public partial class _3thCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "suKiens",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayToChuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaDiem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suKiens", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ves",
                columns: table => new
                {
                    MaVe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiVe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaVe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaSuKien = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ves", x => x.MaVe);
                    table.ForeignKey(
                        name: "FK_ves_suKiens_MaSuKien",
                        column: x => x.MaSuKien,
                        principalTable: "suKiens",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ves_MaSuKien",
                table: "ves",
                column: "MaSuKien");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ves");

            migrationBuilder.DropTable(
                name: "suKiens");
        }
    }
}
