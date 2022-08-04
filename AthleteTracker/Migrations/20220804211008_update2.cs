using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AthleteTracker.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SportId",
                table: "AthleteSponsor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportId);
                });

            migrationBuilder.CreateTable(
                name: "AthleteSport",
                columns: table => new
                {
                    AthleteSportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AthleteId = table.Column<int>(type: "int", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteSport", x => x.AthleteSportId);
                    table.ForeignKey(
                        name: "FK_AthleteSport_Athletes_AthleteId",
                        column: x => x.AthleteId,
                        principalTable: "Athletes",
                        principalColumn: "AthleteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AthleteSport_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AthleteSponsor_SportId",
                table: "AthleteSponsor",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_AthleteSport_AthleteId",
                table: "AthleteSport",
                column: "AthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_AthleteSport_SportId",
                table: "AthleteSport",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_AthleteSponsor_Sports_SportId",
                table: "AthleteSponsor",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "SportId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AthleteSponsor_Sports_SportId",
                table: "AthleteSponsor");

            migrationBuilder.DropTable(
                name: "AthleteSport");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropIndex(
                name: "IX_AthleteSponsor_SportId",
                table: "AthleteSponsor");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "AthleteSponsor");
        }
    }
}
