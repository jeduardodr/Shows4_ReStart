using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shows4.App.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAll1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Episodes_EpisodeId",
                table: "Seasons");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Series_SerieId",
                table: "Seasons");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_Seasons_SeasonId",
                table: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Series_SeasonId",
                table: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Seasons_EpisodeId",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Seasons_SerieId",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "EpisodeId",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "RatingGlobal",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "SerieId",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "RatingGlobal",
                table: "Episodes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Series",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EpisodeId",
                table: "Seasons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Seasons",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RatingGlobal",
                table: "Seasons",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "SerieId",
                table: "Seasons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Episodes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RatingGlobal",
                table: "Episodes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Series_SeasonId",
                table: "Series",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_EpisodeId",
                table: "Seasons",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_SerieId",
                table: "Seasons",
                column: "SerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Episodes_EpisodeId",
                table: "Seasons",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Series_SerieId",
                table: "Seasons",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Seasons_SeasonId",
                table: "Series",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
