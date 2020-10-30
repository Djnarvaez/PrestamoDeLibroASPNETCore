using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIBook.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    IdAutor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Nacionalidad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.IdAutor);
                });

            migrationBuilder.CreateTable(
                name: "Estudiante",
                columns: table => new
                {
                    IdLector = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CI = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Carrera = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.IdLector);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    IdLibro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: true),
                    Editorial = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.IdLibro);
                });

            migrationBuilder.CreateTable(
                name: "LibAut",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAutor = table.Column<int>(nullable: false),
                    IdLibro = table.Column<int>(nullable: false),
                    AutorIdAutor = table.Column<int>(nullable: true),
                    LibroIdLibro = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibAut", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibAut_Autor_AutorIdAutor",
                        column: x => x.AutorIdAutor,
                        principalTable: "Autor",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LibAut_Libro_LibroIdLibro",
                        column: x => x.LibroIdLibro,
                        principalTable: "Libro",
                        principalColumn: "IdLibro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prestamo",
                columns: table => new
                {
                    IdPrestamo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLector = table.Column<int>(nullable: false),
                    IdLibro = table.Column<int>(nullable: false),
                    FechaPrestamo = table.Column<DateTime>(nullable: false),
                    FechaDevolucion = table.Column<DateTime>(nullable: true),
                    Devuelto = table.Column<bool>(nullable: false),
                    EstudianteIdLector = table.Column<int>(nullable: true),
                    LibroIdLibro = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamo", x => x.IdPrestamo);
                    table.ForeignKey(
                        name: "FK_Prestamo_Estudiante_EstudianteIdLector",
                        column: x => x.EstudianteIdLector,
                        principalTable: "Estudiante",
                        principalColumn: "IdLector",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prestamo_Libro_LibroIdLibro",
                        column: x => x.LibroIdLibro,
                        principalTable: "Libro",
                        principalColumn: "IdLibro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibAut_AutorIdAutor",
                table: "LibAut",
                column: "AutorIdAutor");

            migrationBuilder.CreateIndex(
                name: "IX_LibAut_LibroIdLibro",
                table: "LibAut",
                column: "LibroIdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_EstudianteIdLector",
                table: "Prestamo",
                column: "EstudianteIdLector");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_LibroIdLibro",
                table: "Prestamo",
                column: "LibroIdLibro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibAut");

            migrationBuilder.DropTable(
                name: "Prestamo");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Estudiante");

            migrationBuilder.DropTable(
                name: "Libro");
        }
    }
}
