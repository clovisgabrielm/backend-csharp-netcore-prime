using Microsoft.EntityFrameworkCore.Migrations;

namespace web.api.Migrations
{
    public partial class spUpdateInstituicaoFinanceiraClientePF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_SCHEMA = 'SpUpdateInstituicaoFinanceiraClientePF')
                                BEGIN
                                    DROP PROCEDURE SpUpdateInstituicaoFinanceiraClientePF
                                END
                                GO


                                CREATE PROCEDURE SpUpdateInstituicaoFinanceiraClientePF
                                    (
	                                    @Identificador int,
	                                    @InstituicaoFinanceira nvarchar(MAX)
                                    )
                                    AS
                                    BEGIN
	                                    UPDATE [dbo].[ClientesPessoaFisica]
	                                    SET InstituicaoFinanceira = @InstituicaoFinanceira
	                                    WHERE Identificador = @Identificador
                                    END";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE SpUpdateInstituicaoFinanceiraClientePF";

            migrationBuilder.Sql(procedure);

        }
    }
}
