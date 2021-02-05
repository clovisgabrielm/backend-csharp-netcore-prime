namespace PrimeControl.Core.Repositorio
{
    using System.Collections.Generic;
    using PrimeControl.Core.Modelo;

    /// <summary>
    /// Interface para abstração do repositório de cliente pessoa juridica
    /// </summary>    
    public interface IRepositorioClientePessoaJuridica
    {
        /// <summary>
        /// Obtém as empresas.
        /// </summary>
        /// <returns>A lista com todas as entidades de clientes pessoa juridica encontrados.</returns>
        IEnumerable<ClientePessoaJuridica> ObterTodos();

        /// <summary>
        /// Obtém as empresas.
        /// </summary>
        /// <returns>A lista com todas as entidades de clientes.</returns>
        ClientePessoaJuridica ObterClientePessoaJuridica(int id);

        public void EditarInstituicaoFinanceiraClientePJ(int identificador, string instituicaoFinanceira);


        void DeletarClientePessoaJuridica(int id);

        public void CadastrarClientePessoaJuridica(ClientePessoaJuridica clientePessoaJuridica);

        public void EditarClientePessoaJuridica(ClientePessoaJuridica clientePessoaJuridica);
    }
}