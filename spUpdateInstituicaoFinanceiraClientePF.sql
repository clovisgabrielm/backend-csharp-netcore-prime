IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_SCHEMA = 'SpUpdateInstituicaoFinanceiraClientePJ')
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
END