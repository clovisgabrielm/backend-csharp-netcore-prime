namespace PrimeControl.Core.Services.Impl
{
    using System.Collections.Generic;

    using PrimeControl.Core.Modelo;
    using PrimeControl.Core.Repositorio;

    /// <summary>
    /// Implementação concreta do serviço de domínio de clientes pessoa fisica
    /// </summary>
    public class ServicoDominioClientePessoaFisica : IServicoDominioClientePessoaFisica
    {
        private IRepositorioClientePessoaFisica _repositorio;

        public ServicoDominioClientePessoaFisica(IRepositorioClientePessoaFisica repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<ClientePessoaFisica> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }

        public ClientePessoaFisica ObterClientePessoaFisica(int id)
        {
            return _repositorio.ObterClientePessoaFisica(id);
        }

        public void EditarInstituicaoFinanceiraClientePF(int id, string instituicaoFinanceira)
        {
            _repositorio.EditarInstituicaoFinanceiraClientePF(id, instituicaoFinanceira);
        }

        public int ObterIdentificadorClientePorCPF(string cpf)
        {
            return _repositorio.ObterIdentificadorClientePorCPF(cpf);

        }
        public IEnumerable<Contato> ObterContatosClientePF(int id)
        {
            return _repositorio.ObterContatosClientePF(id);
        }

        public void CadastrarContatoClientePF(Contato contato)
        {
            _repositorio.CadastrarContatoClientePF(contato);
        }

        public void EditarContatoClientePF(Contato contato)
        {
            _repositorio.EditarContatoClientePF(contato);
        }


        public void CadastrarClientePessoaFisica(ClientePessoaFisica clientePessoaFisica)
        {
            _repositorio.CadastrarClientePessoaFisica(clientePessoaFisica);
        }

        public void EditarClientePessoaFisica(ClientePessoaFisica clientePessoaFisica)
        {
            _repositorio.EditarClientePessoaFisica(clientePessoaFisica);
        }

        public void DeletarClientePessoaFisica(int id)
        {
            _repositorio.DeletarClientePessoaFisica(id);
        }

    }
}