using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "Genre", "Rating", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "Frank Darabont", "Drama", 9.3m, 1994, "The Shawshank Redemption" },
                    { 2, "Francis Ford Coppola", "Crime", 9.2m, 1972, "The Godfather" },
                    { 3, "Christopher Nolan", "Action", 9.0m, 2008, "The Dark Knight" },
                    { 4, "Quentin Tarantino", "Crime", 8.9m, 1994, "Pulp Fiction" },
                    { 5, "Robert Zemeckis", "Drama", 8.8m, 1994, "Forrest Gump" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
