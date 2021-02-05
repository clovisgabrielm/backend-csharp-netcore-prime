namespace PrimeControl.WebAPI.ServicoAplicacao
{
    using System.Collections.Generic;
    using PrimeControl.Core.Modelo;
    using PrimeControl.WebAPI.Contratos;

    /// <summary>
    /// Interface para abstração do serviço de aplicação de cliente pessoa juridica
    /// </summary>
    public interface IServicoAplicacaoClientePessoaJuridica
    {

        IEnumerable<ContratoRetornoClientePessoaJuridica> ObterClientesPessoaJuridica();

        ContratoRetornoClientePessoaJuridica ObterClientePessoaJuridica(int id);

        void DeletarClientePessoaJuridica(int id);

        public void EditarInstituicaoFinanceiraClientePJ(int identificador, string instituicaoFinanceira);

        public void CadastrarClientePessoaJuridica(ClientePessoaJuridica clientePessoaJuridica);

        public void EditarClientePessoaJuridica(ClientePessoaJuridica clientePessoaJuridica);
    }
}