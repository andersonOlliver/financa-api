using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financa.Infra.Migrations
{
    public partial class AdicionaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Lancamentos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, precision: 100, nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_UsuarioId",
                table: "Lancamentos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_Usuarios_UsuarioId",
                table: "Lancamentos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_Usuarios_UsuarioId",
                table: "Lancamentos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Lancamentos_UsuarioId",
                table: "Lancamentos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Lancamentos");
        }
    }
}
