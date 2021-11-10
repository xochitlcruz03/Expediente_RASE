using Microsoft.EntityFrameworkCore.Migrations;

namespace Expediente_RASE.Migrations
{
    public partial class Usuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_USUARIOS",
                columns: table => new
                {
                    ID_USER = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CORREO_U = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CONTRA_U = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CARGO_U = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.ID_USER);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USUARIOS");
        }
    }
}
