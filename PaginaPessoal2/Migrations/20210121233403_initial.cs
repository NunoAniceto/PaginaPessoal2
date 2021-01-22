using Microsoft.EntityFrameworkCore.Migrations;

namespace PaginaPessoal2.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experiencia",
                columns: table => new
                {
                    ExperienciaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<string>(nullable: true),
                    Empresa = table.Column<string>(nullable: true),
                    Cargo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiencia", x => x.ExperienciaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experiencia");
        }
    }
}
