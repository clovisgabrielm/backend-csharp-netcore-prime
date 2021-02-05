using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace web.api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientesPessoaFisica",
                columns: table => new
                {
                    Identificador = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituicaoFinanceira = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesPessoaFisica", x => x.Identificador);
                });

            migrationBuilder.CreateTable(
                name: "ClientesPessoaJuridica",
                columns: table => new
                {
                    Identificador = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituicaoFinanceira = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    NomeFantasia = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesPessoaJuridica", x => x.Identificador);
                });

            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    Identificador = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefone = table.Column<string>(nullable: true),
                    ClientePessoaFisicaIdentificador = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.Identificador);
                    table.ForeignKey(
                        name: "FK_Contato_ClientesPessoaFisica_ClientePessoaFisicaIdentificador",
                        column: x => x.ClientePessoaFisicaIdentificador,
                        principalTable: "ClientesPessoaFisica",
                        principalColumn: "Identificador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClientesPessoaFisica",
                columns: new[] { "Identificador", "CPF", "DataCadastro", "InstituicaoFinanceira", "Nome" },
                values: new object[] { 1, "152555455445", new DateTime(1, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Banco 1", "Cliente 1" });

            migrationBuilder.CreateIndex(
                name: "IX_Contato_ClientePessoaFisicaIdentificador",
                table: "Contato",
                column: "ClientePessoaFisicaIdentificador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientesPessoaJuridica");

            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropTable(
                name: "ClientesPessoaFisica");
        }
    }
}
