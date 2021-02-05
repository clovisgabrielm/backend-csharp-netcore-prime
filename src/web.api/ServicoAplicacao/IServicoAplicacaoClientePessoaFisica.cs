namespace PrimeControl.WebAPI.ServicoAplicacao
{
    using System.Collections.Generic;
    using PrimeControl.Core.Modelo;
    using PrimeControl.WebAPI.Contratos;

    /// <summary>
    /// Interface para abstração do serviço de aplicação de cliente pessoa fisica
    /// </summary>
    public interface IServicoAplicacaoClientePessoaFisica
    {

        IEnumerable<ContratoRetornoClientePessoaFisica> ObterClientesPessoaFisica();

        ContratoRetornoClientePessoaFisica ObterClientePessoaFisica(int id);

        void DeletarClientePessoaFisica(int id);

        IEnumerable<ContratoRetornoContato> ObterContatosClientePF(int id);

        public void EditarInstituicaoFinanceiraClientePF(int identificador, string instituicaoFinanceira);

        public void CadastrarContatoClientePF(Contato contato);

        public void EditarContatoClientePF(Contato contato);

        public int ObterIdentificadorClientePorCPF(string cpf);

        public void CadastrarClientePessoaFisica(ClientePessoaFisica clientePessoaFisica);

        public void EditarClientePessoaFisica(ClientePessoaFisica clientePessoaFisica);
    }
}