using System.Collections.Generic;
using System.Data;
using System.Linq;
using PrimeControl.Core.Modelo;
using Dapper;
using PrimeControl.Core;

namespace PrimeControl.Core.Repositorio.Impl
{


    /// <summary>
    /// Implementação concreta do repositório de clientes pessoa fisica
    /// </summary>
    public class RepositorioClientePessoaFisica : IRepositorioClientePessoaFisica
    {
        private IDbConnection _connection;

        public RepositorioClientePessoaFisica(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<ClientePessoaFisica> ObterTodos()
        {
            var retorno = _connection.Query<ClientePessoaFisica>(@"
                SELECT *  FROM ClientesPessoaFisica
            ");           
            return retorno;
        }

        public ClientePessoaFisica ObterClientePessoaFisica(int id)
        {
            var retorno = _connection.Query<ClientePessoaFisica>(@"
                SELECT *  FROM ClientesPessoaFisica WHERE Identificador = " + id
            ).FirstOrDefault();
            return retorno;
        }

        public void CadastrarClientePessoaFisica(ClientePessoaFisica clientePessoaFisica)
        {
            _connection.Query<ClientePessoaFisica>(@"
                INSERT INTO ClientesPessoaFisica VALUES ('"
               + clientePessoaFisica.InstituicaoFinanceira + "', '"
               + clientePessoaFisica.Nome + "','"
               + clientePessoaFisica.CPF + "', '"
               + clientePessoaFisica.DataCadastro.ToString("yyyy-MM-ddT00:00:00") + "' );"
           );
        }

        public void CadastrarContatoClientePF(Contato contato)
        {
            _connection.Query<Contato>(@"
                INSERT INTO Contato VALUES ('"
               + contato.Telefone + "','"
               + contato.ClientePessoaFisicaIdentificador + "' );"
           );
        }

        public void EditarContatoClientePF(Contato contato)
        {
            _connection.Query<Contato>(@"
                UPDATE Contato SET Telefone = '"
               + contato.Telefone + "', ClientePessoaFisicaIdentificador = '"
               + contato.ClientePessoaFisicaIdentificador
               + "' WHERE Identificador = " + contato.Identificador + ";"
           );
        }

        public int ObterIdentificadorClientePorCPF(string cpf)
        {
            var retorno = _connection.Query<Cliente>(@"
                SELECT *  FROM ClientesPessoaFisica WHERE CPF = '" + cpf + "';").FirstOrDefault();
            return retorno.Identificador;
        }

        public void EditarClientePessoaFisica(ClientePessoaFisica clientePessoaFisica)
        {
            _connection.Query<ClientePessoaFisica>(@"
                UPDATE ClientesPessoaFisica SET InstituicaoFinanceira = '"
               + clientePessoaFisica.InstituicaoFinanceira + "', Nome = '"
               + clientePessoaFisica.Nome + "', CPF = '"
               + clientePessoaFisica.CPF + "', DataCadastro = '"
               + clientePessoaFisica.DataCadastro.ToString("yyyy-MM-ddT00:00:00")
               + "' WHERE Identificador = " + clientePessoaFisica.Identificador + ";"
           );
        }


        public void EditarInstituicaoFinanceiraClientePF(int identificador, string instituicaoFinanceira)
        {
            _connection.Query<ClientePessoaFisica>(@"
                EXEC [dbo].[SpUpdateInstituicaoFinanceiraClientePF] @Identificador = '"
                    + identificador.ToString() + "', @InstituicaoFinanceira = '"
                    + instituicaoFinanceira + "'");
        }

        public void DeletarClientePessoaFisica(int id)
        {

            _connection.Query<ClientePessoaFisica>(@"
                DELETE FROM ClientesPessoaFisica WHERE Identificador = "
               + id + ";"
           );
        }

        public IEnumerable<Contato> ObterContatosClientePF(int id)
        {
            var retorno = _connection.Query<Contato>(@"
                SELECT * FROM Contato WHERE ClientePessoaFisicaIdentificador = " + id
            );
            return retorno;
        }
    }
}