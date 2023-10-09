using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shows4.App.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateCast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cod",
                table: "Genres");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cod",
                table: "Genres",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);
        }
    }
}
