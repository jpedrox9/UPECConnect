using Microsoft.EntityFrameworkCore.Migrations;

namespace UPECConnect.Migrations
{
    public partial class Config : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Config",
                columns: table => new
                {
                    Empresa = table.Column<int>(type: "int", nullable: false),
                    Images_Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logs_Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Servidor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseDados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Utilizador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebService = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Serie = table.Column<short>(type: "smallint", nullable: false),
                    Setor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.Empresa);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Config");
        }
    }
}
