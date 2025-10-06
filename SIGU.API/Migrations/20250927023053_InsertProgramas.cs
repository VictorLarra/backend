using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIGU.API.Migrations
{
    /// <inheritdoc />
    public partial class InsertProgramas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "programas",
                columns: new[] { "programaid", "nombre" },
                values: new object[,]
                {
                    { 1, "Ingeniería de Sistemas" },
                    { 2, "Ingeniería Civil" },
                    { 3, "Ingeniería Mecatrónica" },
                    { 4, "Arquitectura" },
                    { 5, "Ingeniería de Telecomunicacioes" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "programas",
                keyColumn: "programaid",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "programas",
                keyColumn: "programaid",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "programas",
                keyColumn: "programaid",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "programas",
                keyColumn: "programaid",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "programas",
                keyColumn: "programaid",
                keyValue: 5);
        }
    }
}
