using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORT_PORTAL_ABOGADOS.Migrations
{
    /// <inheritdoc />
    public partial class IdAbogado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAbogado",
                table: "Consultas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "IdAbogado",
                table: "Consultas");
        }
    }
}
