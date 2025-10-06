using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SIGU.API.Migrations
{
    /// <inheritdoc />
    public partial class AddProgramaAndRelacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "programas",
                columns: table => new
                {
                    programaid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programas", x => x.programaid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_programaid",
                table: "usuarios",
                column: "programaid");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_programas_programaid",
                table: "usuarios",
                column: "programaid",
                principalTable: "programas",
                principalColumn: "programaid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_programas_programaid",
                table: "usuarios");

            migrationBuilder.DropTable(
                name: "programas");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_programaid",
                table: "usuarios");
        }
    }
}
