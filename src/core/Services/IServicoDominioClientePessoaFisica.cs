namespace PrimeControl.Core.Services
{
    using System.Collections.Generic;

    using PrimeControl.Core.Modelo;

    /// <summary>
    /// Interface para abstração do serviço de domínio de clientes pessoa fisica
    /// </summary>
    public interface IServicoDominioClientePessoaFisica
    {
        /// <summary>
        /// Obtém os clientes.
        /// </summary>
        /// <returns>A lista com todas as entidades de cliente encontradas.</returns>
        IEnumerable<ClientePessoaFisica> ObterTodos();

        /// <summary>
        /// Obtém cliente.
        /// </summary>
        /// <returns>O cliente encontrado.</returns>
        ClientePessoaFisica ObterClientePessoaFisica(int id);

        public int ObterIdentificadorClientePorCPF(string cpf);

        public void EditarInstituicaoFinanceiraClientePF(int identificador, string instituicaoFinanceira);


        public void CadastrarContatoClientePF(Contato contato);

        public void EditarContatoClientePF(Contato contato);


        IEnumerable<Contato> ObterContatosClientePF(int id);

        void DeletarClientePessoaFisica(int id);

        public void CadastrarClientePessoaFisica(ClientePessoaFisica clientePessoaFisica);
        public void EditarClientePessoaFisica(ClientePessoaFisica clientePessoaFisica);
    }
}