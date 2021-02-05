namespace PrimeControl.WebAPI.Controllers
{
    using System.Collections.Generic;
    using System;
    using PrimeControl.WebAPI.Contratos;
    using PrimeControl.WebAPI.ServicoAplicacao;
    using Microsoft.AspNetCore.Mvc;
    using PrimeControl.Core.Modelo;
    using System.Linq;
    using PrimeControl.WebAPI.Parsers;

    /// <summary>
    /// Controladora de Clientes Pessoa Fisica
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClientesPessoaFisicaController : ControllerBase
    {
        private IServicoAplicacaoClientePessoaFisica _servicoAplicacaoCliente;

        public ClientesPessoaFisicaController(IServicoAplicacaoClientePessoaFisica servicoAplicacaoCliente)
        {
            _servicoAplicacaoCliente = servicoAplicacaoCliente;
        }

        /// <summary>
        /// Obtém todos os clientes cadastradas.
        /// </summary>
        /// <returns>Os clientes cadastrados.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ContratoRetornoClientePessoaFisica>> ObterTodos()
        {
            try
            {
                return Ok(_servicoAplicacaoCliente.ObterClientesPessoaFisica());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtém um cliente cadastrado.
        /// </summary>
        /// <returns>Um cliente cadastrado.</returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<ContratoRetornoClientePessoaFisica> ObterClientePessoaFisica(int id)
        {
            try
            {
                ContratoRetornoClientePessoaFisica clientePessoaFisica = _servicoAplicacaoCliente.ObterClientePessoaFisica(id);
                clientePessoaFisica.Contatos = new List<Contato>();
                IEnumerable<ContratoRetornoContato> contatos = _servicoAplicacaoCliente.ObterContatosClientePF(id);

                if (clientePessoaFisica == null)
                {
                    return NotFound();
                }

                if (contatos.Count() > 0)
                {
                    foreach (ContratoRetornoContato contato in contatos)
                    {
                        clientePessoaFisica.Contatos.Add(ContatoParser.Converter(contato));
                    }
                }

                return Ok(clientePessoaFisica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("contatos")]
        public IActionResult CadastrarContatosCliente(IList<Contato> contatos)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            foreach (Contato contato in contatos)
            {
                _servicoAplicacaoCliente.CadastrarContatoClientePF(contato);
            }

            return Ok();
        }

        /// <summary>
        /// Cadastra um cliente.
        /// </summary>
        [HttpPost]
        public IActionResult CadastrarClientePessoaFisica(ClientePessoaFisica clientePessoaFisica)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            _servicoAplicacaoCliente.CadastrarClientePessoaFisica(clientePessoaFisica);

            int id = _servicoAplicacaoCliente.ObterIdentificadorClientePorCPF(clientePessoaFisica.CPF);

            foreach (Contato contato in clientePessoaFisica.Contatos)
            {
                contato.ClientePessoaFisicaIdentificador = id;
                _servicoAplicacaoCliente.CadastrarContatoClientePF(contato);
            }
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult EditarClientePessoaFisica(int id, ClientePessoaFisica clientePessoaFisica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientePessoaFisica.Identificador)
            {
                return BadRequest();
            }

            _servicoAplicacaoCliente.EditarClientePessoaFisica(clientePessoaFisica);

            foreach(Contato contato in clientePessoaFisica.Contatos)
            {
                _servicoAplicacaoCliente.EditarContatoClientePF(contato);
            }

            return NoContent();
        }

        [HttpPut]
        [Route("instituicaoFinanceira/{id}")]
        public IActionResult EditarInstituicaoFinanceiraClientePF(int id, ClientePessoaFisica clientePessoaFisica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientePessoaFisica.Identificador)
            {
                return BadRequest();
            }

            _servicoAplicacaoCliente.EditarInstituicaoFinanceiraClientePF(id, clientePessoaFisica.InstituicaoFinanceira);

            return NoContent();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeletarClientePessoaFisica(int id)
        {

            ContratoRetornoClientePessoaFisica clientePessoaFisica = _servicoAplicacaoCliente.ObterClientePessoaFisica(id);
            if (clientePessoaFisica == null)
            {
                return NotFound();
            }

            _servicoAplicacaoCliente.DeletarClientePessoaFisica(clientePessoaFisica.Identificador);

            return Ok(clientePessoaFisica);
        }


    }
}