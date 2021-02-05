using Microsoft.EntityFrameworkCore.Migrations;

namespace web.api.Migrations
{
    public partial class spUpdateInstituicaoFinanceiraClientePJ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_SCHEMA = 'SpUpdateInstituicaoFinanceiraClientePJ')
                                BEGIN
                                    DROP PROCEDURE SpUpdateInstituicaoFinanceiraClientePJ
                                END
                                GO


                                CREATE PROCEDURE SpUpdateInstituicaoFinanceiraClientePJ
                                    (
	                                    @Identificador int,
	                                    @InstituicaoFinanceira nvarchar(MAX)
                                    )
                                    AS
                                    BEGIN
	                                    UPDATE [dbo].[ClientesPessoaJuridica]
	                                    SET InstituicaoFinanceira = @InstituicaoFinanceira
	                                    WHERE Identificador = @Identificador
                                    END";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE SpUpdateInstituicaoFinanceiraClientePJ";

            migrationBuilder.Sql(procedure);
        }
    }
}
