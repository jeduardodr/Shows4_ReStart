using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shows4.App.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCast1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casts_Episodes_EpisodeId",
                table: "Casts");

            migrationBuilder.DropIndex(
                name: "IX_Casts_EpisodeId",
                table: "Casts");

            migrationBuilder.DropColumn(
                name: "EpisodeId",
                table: "Casts");

            migrationBuilder.CreateTable(
                name: "CastEpisode",
                columns: table => new
                {
                    CastsId = table.Column<int>(type: "int", nullable: false),
                    EpisodesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastEpisode", x => new { x.CastsId, x.EpisodesId });
                    table.ForeignKey(
                        name: "FK_CastEpisode_Casts_CastsId",
                        column: x => x.CastsId,
                        principalTable: "Casts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CastEpisode_Episodes_EpisodesId",
                        column: x => x.EpisodesId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CastEpisode_EpisodesId",
                table: "CastEpisode",
                column: "EpisodesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CastEpisode");

            migrationBuilder.AddColumn<int>(
                name: "EpisodeId",
                table: "Casts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Casts_EpisodeId",
                table: "Casts",
                column: "EpisodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Casts_Episodes_EpisodeId",
                table: "Casts",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id");
        }
    }
}
