namespace PrimeControl.WebAPI.Parsers
{
    using System.Collections.Generic;
    using System.Linq;

    using PrimeControl.WebAPI.Contratos;
    using PrimeControl.Core.Modelo;

    /// <summary>
    /// Mapeador entre entidades e DTOs de empresas
    /// </summary>
    public static class ClientePessoaJuridicaParser
    {
        /// <summary>
        /// Converte um modelo de domínio de empresa em um DTO de empresa.
        /// </summary>
        /// <param name="clientePessoaJuridica">O modelo a ser convertido.</param>
        /// <returns>O DTO convertido.</returns>
        public static ContratoRetornoClientePessoaJuridica Converter(ClientePessoaJuridica clientePessoaJuridica)
        {
            return new ContratoRetornoClientePessoaJuridica
            {
                Identificador = clientePessoaJuridica.Identificador,
                NomeFantasia = clientePessoaJuridica.NomeFantasia,
                CNPJ = clientePessoaJuridica.CNPJ,
                UF = clientePessoaJuridica.UF,
                InstituicaoFinanceira = clientePessoaJuridica.InstituicaoFinanceira
            };
        }

        /// <summary>
        /// Converte um DTO de empresa em um modelo de domínio de empresa.
        /// </summary>
        /// <param name="cliente">O DTO a ser convertido.</param>
        /// <returns>O modelo convertido.</returns>
        public static ClientePessoaJuridica Converter(ContratoRetornoClientePessoaJuridica contratoRetornoClientePessoaJuridica)
        {
            return new ClientePessoaJuridica
            {
                Identificador = contratoRetornoClientePessoaJuridica.Identificador,
                NomeFantasia = contratoRetornoClientePessoaJuridica.NomeFantasia,
                CNPJ = contratoRetornoClientePessoaJuridica.CNPJ,
                InstituicaoFinanceira = contratoRetornoClientePessoaJuridica.InstituicaoFinanceira
            };
        }

        /// <summary>
        /// Converte uma lista de modelos de domínio de empresa em uma lista de DTOs de empresa.
        /// </summary>
        /// <param name="clientePessoaFisica">Os modelos a serem convertidos.</param>
        /// <returns>Os DTOs convertidos.</returns>
        public static IEnumerable<ContratoRetornoClientePessoaJuridica> Converter(IEnumerable<ClientePessoaJuridica> clientes)
        {
            return clientes.Select(cliente => Converter(cliente));
        }
    }
}