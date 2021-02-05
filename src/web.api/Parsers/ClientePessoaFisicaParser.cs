namespace PrimeControl.WebAPI.Parsers
{
    using System.Collections.Generic;
    using System.Linq;

    using PrimeControl.WebAPI.Contratos;
    using PrimeControl.Core.Modelo;

    /// <summary>
    /// Mapeador entre entidades e DTOs de empresas
    /// </summary>
    public static class ClientePessoaFisicaParser
    {
        /// <summary>
        /// Converte um modelo de domínio de empresa em um DTO de empresa.
        /// </summary>
        /// <param name="cliente">O modelo a ser convertido.</param>
        /// <returns>O DTO convertido.</returns>
        public static ContratoRetornoClientePessoaFisica Converter(ClientePessoaFisica clientePessoaFisica)
        {
            return new ContratoRetornoClientePessoaFisica
            {
                Identificador = clientePessoaFisica.Identificador,
                Nome = clientePessoaFisica.Nome,
                CPF = clientePessoaFisica.CPF,
                Contatos = clientePessoaFisica.Contatos,
                DataCadastro = clientePessoaFisica.DataCadastro,
                InstituicaoFinanceira = clientePessoaFisica.InstituicaoFinanceira
            };
        }

        /// <summary>
        /// Converte um DTO de empresa em um modelo de domínio de empresa.
        /// </summary>
        /// <param name="cliente">O DTO a ser convertido.</param>
        /// <returns>O modelo convertido.</returns>
        public static ClientePessoaFisica Converter(ContratoRetornoClientePessoaFisica contratoRetornoClientePessoaFisica)
        {
            return new ClientePessoaFisica
            {
                Nome = contratoRetornoClientePessoaFisica.Nome,
                CPF = contratoRetornoClientePessoaFisica.CPF,
                Contatos = contratoRetornoClientePessoaFisica.Contatos,
                DataCadastro = contratoRetornoClientePessoaFisica.DataCadastro
            };
        }

        /// <summary>
        /// Converte uma lista de modelos de domínio de empresa em uma lista de DTOs de empresa.
        /// </summary>
        /// <param name="clientePessoaFisica">Os modelos a serem convertidos.</param>
        /// <returns>Os DTOs convertidos.</returns>
        public static IEnumerable<ContratoRetornoClientePessoaFisica> Converter(IEnumerable<ClientePessoaFisica> clientes)
        {
            return clientes.Select(cliente => Converter(cliente));
        }
    }
}