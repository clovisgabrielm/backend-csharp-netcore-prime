namespace PrimeControl.Core.Repositorio
{
    using System.Collections.Generic;
    using PrimeControl.Core.Modelo;

    /// <summary>
    /// Interface para abstração do repositório de cliente pessoa física
    /// </summary>    
    public interface IRepositorioClientePessoaFisica
    {
        /// <summary>
        /// Obtém as empresas.
        /// </summary>
        /// <returns>A lista com todas as entidades de clientes pessoa fisica encontrados.</returns>
        IEnumerable<ClientePessoaFisica> ObterTodos();

        /// <summary>
        /// Obtém as empresas.
        /// </summary>
        /// <returns>A lista com todas as entidades de clientes.</returns>
        ClientePessoaFisica ObterClientePessoaFisica(int id);

        public int ObterIdentificadorClientePorCPF(string cpf);

        public void EditarInstituicaoFinanceiraClientePF(int identificador, string instituicaoFinanceira);

        IEnumerable<Contato> ObterContatosClientePF(int id);

        public void CadastrarContatoClientePF(Contato contato);

        public void EditarContatoClientePF(Contato contato);

        void DeletarClientePessoaFisica(int id);

        public void CadastrarClientePessoaFisica(ClientePessoaFisica clientePessoaFisica);

        public void EditarClientePessoaFisica(ClientePessoaFisica clientePessoaFisica);
    }
}