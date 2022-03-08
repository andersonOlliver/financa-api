using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financa.Infra.Migrations
{
    public partial class adicionacartaoitens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_Categorias_CategoriaId",
                table: "Lancamentos");

            migrationBuilder.AddColumn<Guid>(
                name: "CartaoId",
                table: "Lancamentos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Cartoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Limite = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, precision: 100, nullable: false),
                    DiaVencimento = table.Column<byte>(type: "TINYINT", nullable: false),
                    DiaFechamento = table.Column<byte>(type: "TINYINT", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartoes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensLancamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, precision: 100, scale: 2, nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LancamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensLancamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensLancamento_Lancamentos_LancamentoId",
                        column: x => x.LancamentoId,
                        principalTable: "Lancamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_CartaoId",
                table: "Lancamentos",
                column: "CartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cartoes_UsuarioId",
                table: "Cartoes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensLancamento_LancamentoId",
                table: "ItensLancamento",
                column: "LancamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_Cartoes_CartaoId",
                table: "Lancamentos",
                column: "CartaoId",
                principalTable: "Cartoes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_Categorias_CategoriaId",
                table: "Lancamentos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_Cartoes_CartaoId",
                table: "Lancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_Categorias_CategoriaId",
                table: "Lancamentos");

            migrationBuilder.DropTable(
                name: "Cartoes");

            migrationBuilder.DropTable(
                name: "ItensLancamento");

            migrationBuilder.DropIndex(
                name: "IX_Lancamentos_CartaoId",
                table: "Lancamentos");

            migrationBuilder.DropColumn(
                name: "CartaoId",
                table: "Lancamentos");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_Categorias_CategoriaId",
                table: "Lancamentos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
