using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORT_PORTAL_ABOGADOS.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abogados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tomo = table.Column<int>(type: "int", nullable: false),
                    Folio = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<int>(type: "int", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abogados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstaActiva = table.Column<bool>(type: "bit", nullable: false),
                    AbogadoId = table.Column<int>(type: "int", nullable: true),
                    AbogadoId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultas_Abogados_AbogadoId",
                        column: x => x.AbogadoId,
                        principalTable: "Abogados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Consultas_Abogados_AbogadoId1",
                        column: x => x.AbogadoId1,
                        principalTable: "Abogados",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_AbogadoId",
                table: "Consultas",
                column: "AbogadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_AbogadoId1",
                table: "Consultas",
                column: "AbogadoId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Abogados");
        }
    }
}
