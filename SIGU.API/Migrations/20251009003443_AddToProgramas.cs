using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGU.API.Migrations
{
    /// <inheritdoc />
    public partial class AddToProgramas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tipoPrograma",
                table: "usuarios",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipoPrograma",
                table: "usuarios");
        }
    }
}
