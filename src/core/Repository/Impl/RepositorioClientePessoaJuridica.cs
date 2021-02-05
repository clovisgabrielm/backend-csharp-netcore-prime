using System.Collections.Generic;
using System.Data;
using System.Linq;
using PrimeControl.Core.Modelo;
using Dapper;

namespace PrimeControl.Core.Repositorio.Impl
{


    /// <summary>
    /// Implementação concreta do repositório de clientes pessoa juridica
    /// </summary>
    public class RepositorioClientePessoaJuridica : IRepositorioClientePessoaJuridica
    {
        private IDbConnection _connection;

        public RepositorioClientePessoaJuridica(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<ClientePessoaJuridica> ObterTodos()
        {
            var retorno = _connection.Query<ClientePessoaJuridica>(@"
                SELECT *  FROM ClientesPessoaJuridica
            ");           
            return retorno;
        }

        public ClientePessoaJuridica ObterClientePessoaJuridica(int id)
        {
            var retorno = _connection.Query<ClientePessoaJuridica>(@"
                SELECT *  FROM ClientesPessoaJuridica WHERE Identificador = " + id
            ).FirstOrDefault();
            return retorno;
        }

        public void CadastrarClientePessoaJuridica(ClientePessoaJuridica clientePessoaJuridica)
        {
            _connection.Query<ClientePessoaJuridica>(@"
                INSERT INTO ClientesPessoaJuridica VALUES ('"
               + clientePessoaJuridica.InstituicaoFinanceira + "','"
               + clientePessoaJuridica.UF + "', '" + clientePessoaJuridica.NomeFantasia 
               + "', '" + clientePessoaJuridica.CNPJ + "' );"
           );
        }

        public void EditarClientePessoaJuridica(ClientePessoaJuridica clientePessoaJuridica)
        {
            _connection.Query<ClientePessoaJuridica>(@"
                UPDATE ClientesPessoaJuridica SET InstituicaoFinanceira = '"
               + clientePessoaJuridica.InstituicaoFinanceira + "', UF = '"
               + clientePessoaJuridica.UF + "', NomeFantasia = '"
               + clientePessoaJuridica.NomeFantasia + "', CNPJ = '"
               + clientePessoaJuridica.CNPJ
               + "' WHERE Identificador = " + clientePessoaJuridica.Identificador + ";"
           );
        }

        public void EditarInstituicaoFinanceiraClientePJ(int identificador, string instituicaoFinanceira)
        {
            _connection.Query<ClientePessoaJuridica>(@"
                EXEC [dbo].[SpUpdateInstituicaoFinanceiraClientePJ] @Identificador = '"
                    + identificador.ToString() + "', @InstituicaoFinanceira = '"
                    + instituicaoFinanceira + "'");
        }


        public void DeletarClientePessoaJuridica(int id)
        {

            _connection.Query<ClientePessoaJuridica>(@"
                DELETE FROM ClientesPessoaJuridica WHERE Identificador = "
               + id + ";"
           );
        }
    }
}