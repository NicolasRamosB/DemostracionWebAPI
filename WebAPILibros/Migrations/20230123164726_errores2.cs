using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPILibros.Migrations
{
    public partial class errores2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Autor_AutorId",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_AutorId",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Libro");

            migrationBuilder.AddColumn<int>(
                name: "IdAutor",
                table: "Libro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Libro_IdAutor",
                table: "Libro",
                column: "IdAutor");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Autor_IdAutor",
                table: "Libro",
                column: "IdAutor",
                principalTable: "Autor",
                principalColumn: "IdAutor",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Autor_IdAutor",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_IdAutor",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "IdAutor",
                table: "Libro");

            migrationBuilder.AddColumn<int>(
                name: "AutorId",
                table: "Libro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Libro_AutorId",
                table: "Libro",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Autor_AutorId",
                table: "Libro",
                column: "AutorId",
                principalTable: "Autor",
                principalColumn: "IdAutor",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
