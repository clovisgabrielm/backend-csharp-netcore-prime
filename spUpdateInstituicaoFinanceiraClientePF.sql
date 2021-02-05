IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_SCHEMA = 'SpUpdateInstituicaoFinanceiraClientePF')
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
END