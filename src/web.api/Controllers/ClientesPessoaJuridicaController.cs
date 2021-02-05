namespace PrimeControl.WebAPI.Controllers
{
    using System.Collections.Generic;
    using System;

    using PrimeControl.WebAPI.Contratos;
    using PrimeControl.WebAPI.ServicoAplicacao;
    using PrimeControl.Core.Services;

    using Microsoft.AspNetCore.Mvc;
    using PrimeControl.Core.Modelo;
    

    /// <summary>
    /// Controladora de Clientes
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClientesPessoaJuridicaController : ControllerBase
    {
        private IServicoAplicacaoClientePessoaJuridica _servicoAplicacaoCliente;

        public ClientesPessoaJuridicaController(IServicoAplicacaoClientePessoaJuridica servicoAplicacaoCliente)
        {
            _servicoAplicacaoCliente = servicoAplicacaoCliente;
        }

        /// <summary>
        /// Obtém todos os clientes cadastradas.
        /// </summary>
        /// <returns>Os clientes cadastrados.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ContratoRetornoClientePessoaJuridica>> ObterTodos()
        {
            try
            {
                return Ok(_servicoAplicacaoCliente.ObterClientesPessoaJuridica());
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
        public ActionResult<ContratoRetornoClientePessoaJuridica> ObterClientePessoaJuridica(int id)
        {
            try
            {
                ContratoRetornoClientePessoaJuridica clientePessoaJuridica = _servicoAplicacaoCliente.ObterClientePessoaJuridica(id);
                
                if (clientePessoaJuridica == null)
                {
                    return NotFound();
                }

                return Ok(clientePessoaJuridica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        /// <summary>
        /// Cadastra um cliente.
        /// </summary>
        [HttpPost]
        public IActionResult CadastrarClientePessoaJuridica(ClientePessoaJuridica clientePessoaJuridica)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            _servicoAplicacaoCliente.CadastrarClientePessoaJuridica(clientePessoaJuridica);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult EditarClientePessoaJuridica(int id, ClientePessoaJuridica clientePessoaJuridica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientePessoaJuridica.Identificador)
            {
                return BadRequest();
            }

            _servicoAplicacaoCliente.EditarClientePessoaJuridica(clientePessoaJuridica);

            return NoContent();
        }

        [HttpPut]
        [Route("instituicaoFinanceira/{id}")]
        public IActionResult EditarInstituicaoFinanceiraClientePJ(int id, ClientePessoaJuridica clientePessoaJuridica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientePessoaJuridica.Identificador)
            {
                return BadRequest();
            }

            _servicoAplicacaoCliente.EditarInstituicaoFinanceiraClientePJ(id, clientePessoaJuridica.InstituicaoFinanceira);

            return NoContent();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeletarClientePessoaJuridica(int id)
        {

            ContratoRetornoClientePessoaJuridica clientePessoaJuridica = _servicoAplicacaoCliente.ObterClientePessoaJuridica(id);
            if (clientePessoaJuridica == null)
            {
                return NotFound();
            }

            _servicoAplicacaoCliente.DeletarClientePessoaJuridica(clientePessoaJuridica.Identificador);

            return Ok(clientePessoaJuridica);
        }
    }
}