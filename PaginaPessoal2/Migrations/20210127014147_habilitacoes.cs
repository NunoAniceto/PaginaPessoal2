using Microsoft.EntityFrameworkCore.Migrations;

namespace PaginaPessoal2.Migrations
{
    public partial class habilitacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habilitacoes",
                columns: table => new
                {
                    HabilitacoesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<string>(nullable: false),
                    Curso = table.Column<string>(nullable: false),
                    Instituicao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilitacoes", x => x.HabilitacoesId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habilitacoes");
        }
    }
}
