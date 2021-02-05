namespace PrimeControl.WebAPI.ServicoAplicacao.Impl
{
    using System.Collections.Generic;

    using PrimeControl.WebAPI.Parsers;
    using PrimeControl.WebAPI.Contratos;
    using PrimeControl.Core.Services;
    using PrimeControl.Core.Modelo;
    using Microsoft.EntityFrameworkCore.Internal;
    using System.Linq;

    /// <summary>
    /// Implementação concreta do serviço de domínio de clientes pessoa Juridica
    /// </summary>
    public class ServicoAplicacaoClientePessoaJuridica : IServicoAplicacaoClientePessoaJuridica
    {
        private IServicoDominioClientePessoaJuridica _servicoDominioCliente;

        public ServicoAplicacaoClientePessoaJuridica(IServicoDominioClientePessoaJuridica servicoDominioCliente)
        {
            _servicoDominioCliente = servicoDominioCliente;
        }
        
        public IEnumerable<ContratoRetornoClientePessoaJuridica> ObterClientesPessoaJuridica()
        {
            var listaClientesPessoaJuridica = _servicoDominioCliente.ObterTodos();
            return ClientePessoaJuridicaParser.Converter(listaClientesPessoaJuridica);
        }

        public ContratoRetornoClientePessoaJuridica ObterClientePessoaJuridica(int id)
        {
            var clientePessoaJuridica = _servicoDominioCliente.ObterClientePessoaJuridica(id);

            if (clientePessoaJuridica == null)
                return null;

            return ClientePessoaJuridicaParser.Converter(clientePessoaJuridica);
        }

        public void DeletarClientePessoaJuridica(int id)
        {
            _servicoDominioCliente.DeletarClientePessoaJuridica(id);
        }

        public void EditarInstituicaoFinanceiraClientePJ(int identificador, string instituicaoFinanceira)
        {
            _servicoDominioCliente.EditarInstituicaoFinanceiraClientePJ(identificador, instituicaoFinanceira);
        }

        public void CadastrarClientePessoaJuridica(ClientePessoaJuridica clientePessoaJuridica)
        {
            _servicoDominioCliente.CadastrarClientePessoaJuridica(clientePessoaJuridica);
        }


        public void EditarClientePessoaJuridica(ClientePessoaJuridica clientePessoaJuridica)
        {
            _servicoDominioCliente.EditarClientePessoaJuridica(clientePessoaJuridica);
        }
    }
}