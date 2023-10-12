using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shows4.App.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSerie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Series",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Series",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "SerieId",
                table: "Seasons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_SerieId",
                table: "Seasons",
                column: "SerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Series_SerieId",
                table: "Seasons",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Series_SerieId",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Seasons_SerieId",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "SerieId",
                table: "Seasons");
        }
    }
}
