namespace PrimeControl.Core.Services
{
    using System.Collections.Generic;

    using PrimeControl.Core.Modelo;

    /// <summary>
    /// Interface para abstração do serviço de domínio de clientes pessoa juridica
    /// </summary>
    public interface IServicoDominioClientePessoaJuridica
    {
        /// <summary>
        /// Obtém os clientes.
        /// </summary>
        /// <returns>A lista com todas as entidades de cliente encontradas.</returns>
        IEnumerable<ClientePessoaJuridica> ObterTodos();

        /// <summary>
        /// Obtém cliente.
        /// </summary>
        /// <returns>O cliente encontrado.</returns>
        ClientePessoaJuridica ObterClientePessoaJuridica(int id);

        void DeletarClientePessoaJuridica(int id);

        public void EditarInstituicaoFinanceiraClientePJ(int identificador, string instituicaoFinanceira);

        public void CadastrarClientePessoaJuridica(ClientePessoaJuridica clientePessoaJuridica);
        public void EditarClientePessoaJuridica(ClientePessoaJuridica clientePessoaJuridica);
    }
}