namespace PrimeControl.Core.Services.Impl
{
    using System.Collections.Generic;

    using PrimeControl.Core.Modelo;
    using PrimeControl.Core.Repositorio;

    /// <summary>
    /// Implementação concreta do serviço de domínio de clientes pessoa juridica
    /// </summary>
    public class ServicoDominioClientePessoaJuridica : IServicoDominioClientePessoaJuridica
    {
        private IRepositorioClientePessoaJuridica _repositorio;

        public ServicoDominioClientePessoaJuridica(IRepositorioClientePessoaJuridica repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<ClientePessoaJuridica> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }

        public ClientePessoaJuridica ObterClientePessoaJuridica(int id)
        {
            return _repositorio.ObterClientePessoaJuridica(id);
        }

        public void CadastrarClientePessoaJuridica(ClientePessoaJuridica clientePessoaJuridica)
        {
            _repositorio.CadastrarClientePessoaJuridica(clientePessoaJuridica);
        }

        public void EditarClientePessoaJuridica(ClientePessoaJuridica clientePessoaJuridica)
        {
            _repositorio.EditarClientePessoaJuridica(clientePessoaJuridica);
        }


        public void EditarInstituicaoFinanceiraClientePJ(int id, string instituicaoFinanceira)
        {
            _repositorio.EditarInstituicaoFinanceiraClientePJ(id, instituicaoFinanceira);
        }

        public void DeletarClientePessoaJuridica(int id)
        {
            _repositorio.DeletarClientePessoaJuridica(id);
        }

    }
}