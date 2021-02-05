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
    /// Implementação concreta do serviço de domínio de clientes pessoa fisica
    /// </summary>
    public class ServicoAplicacaoClientePessoaFisica : IServicoAplicacaoClientePessoaFisica
    {
        private IServicoDominioClientePessoaFisica _servicoDominioCliente;

        public ServicoAplicacaoClientePessoaFisica(IServicoDominioClientePessoaFisica servicoDominioCliente)
        {
            _servicoDominioCliente = servicoDominioCliente;
        }
        
        public IEnumerable<ContratoRetornoClientePessoaFisica> ObterClientesPessoaFisica()
        {
            var listaClientesPessoaFisica = _servicoDominioCliente.ObterTodos();
            return ClientePessoaFisicaParser.Converter(listaClientesPessoaFisica);
        }

        public void CadastrarContatoClientePF(Contato contato)
        {
            _servicoDominioCliente.CadastrarContatoClientePF(contato);
        }

        public void EditarContatoClientePF(Contato contato)
        {
            _servicoDominioCliente.EditarContatoClientePF(contato);
        }


        public int ObterIdentificadorClientePorCPF(string cpf)
        {
            int id = _servicoDominioCliente.ObterIdentificadorClientePorCPF(cpf);

            return id;
        }


        public void EditarInstituicaoFinanceiraClientePF(int identificador, string instituicaoFinanceira)
        {
            _servicoDominioCliente.EditarInstituicaoFinanceiraClientePF(identificador, instituicaoFinanceira);
        }

        public ContratoRetornoClientePessoaFisica ObterClientePessoaFisica(int id)
        {
            var clientePessoaFisica = _servicoDominioCliente.ObterClientePessoaFisica(id);

            if (clientePessoaFisica == null)
                return null;

            return ClientePessoaFisicaParser.Converter(clientePessoaFisica);
        }


        public IEnumerable<ContratoRetornoContato> ObterContatosClientePF(int id)
        {
            IEnumerable<Contato> contatos = _servicoDominioCliente.ObterContatosClientePF(id);

            if (!contatos.Any())
                return null;

            return ContatoParser.Converter(contatos);
        }


        public void DeletarClientePessoaFisica(int id)
        {
            _servicoDominioCliente.DeletarClientePessoaFisica(id);
        }

        public void CadastrarClientePessoaFisica(ClientePessoaFisica clientePessoaFisica)
        {
            _servicoDominioCliente.CadastrarClientePessoaFisica(clientePessoaFisica);
        }


        public void EditarClientePessoaFisica(ClientePessoaFisica clientePessoaFisica)
        {
            _servicoDominioCliente.EditarClientePessoaFisica(clientePessoaFisica);
        }
    }
}