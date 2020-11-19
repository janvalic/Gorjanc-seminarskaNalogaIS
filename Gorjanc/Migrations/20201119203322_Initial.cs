using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gorjanc.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oseba",
                columns: table => new
                {
                    OsebaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Priimek = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oseba", x => x.OsebaId);
                });

            migrationBuilder.CreateTable(
                name: "Vrh",
                columns: table => new
                {
                    VrhId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Visina = table.Column<int>(nullable: false),
                    Koordinate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vrh", x => x.VrhId);
                });

            migrationBuilder.CreateTable(
                name: "Obisk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OsebaId = table.Column<int>(nullable: false),
                    VrhId = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obisk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obisk_Oseba_OsebaId",
                        column: x => x.OsebaId,
                        principalTable: "Oseba",
                        principalColumn: "OsebaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Obisk_Vrh_VrhId",
                        column: x => x.VrhId,
                        principalTable: "Vrh",
                        principalColumn: "VrhId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slika",
                columns: table => new
                {
                    SlikaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrhId = table.Column<int>(nullable: false),
                    Img = table.Column<byte[]>(nullable: true),
                    DatumSlike = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slika", x => x.SlikaId);
                    table.ForeignKey(
                        name: "FK_Slika_Vrh_VrhId",
                        column: x => x.VrhId,
                        principalTable: "Vrh",
                        principalColumn: "VrhId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Obisk_OsebaId",
                table: "Obisk",
                column: "OsebaId");

            migrationBuilder.CreateIndex(
                name: "IX_Obisk_VrhId",
                table: "Obisk",
                column: "VrhId");

            migrationBuilder.CreateIndex(
                name: "IX_Slika_VrhId",
                table: "Slika",
                column: "VrhId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obisk");

            migrationBuilder.DropTable(
                name: "Slika");

            migrationBuilder.DropTable(
                name: "Oseba");

            migrationBuilder.DropTable(
                name: "Vrh");
        }
    }
}
