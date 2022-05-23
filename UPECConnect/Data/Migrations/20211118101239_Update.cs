using Microsoft.EntityFrameworkCore.Migrations;

namespace UPECConnect.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilhosViewModel");

            migrationBuilder.DropTable(
                name: "TesteModelo");

            migrationBuilder.DropTable(
                name: "RegTesteModViewModel");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersEmpresas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UsersEmpresas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RegTesteModViewModel",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Acesso = table.Column<bool>(type: "bit", nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Morada2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegTesteModViewModel", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "TesteModelo",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Acesso = table.Column<bool>(type: "bit", nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Morada2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TesteModelo", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "FilhosViewModel",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegTesteModViewModelcodigo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilhosViewModel", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_FilhosViewModel_RegTesteModViewModel_RegTesteModViewModelcodigo",
                        column: x => x.RegTesteModViewModelcodigo,
                        principalTable: "RegTesteModViewModel",
                        principalColumn: "codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilhosViewModel_RegTesteModViewModelcodigo",
                table: "FilhosViewModel",
                column: "RegTesteModViewModelcodigo");
        }
    }
}
