using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financa.Infra.Migrations
{
    public partial class adicionacartao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Parcela",
                table: "ItensLancamento",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parcela",
                table: "ItensLancamento");
        }
    }
}
