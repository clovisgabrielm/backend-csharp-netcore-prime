namespace PrimeControl.WebAPI.Parsers
{
    using System.Collections.Generic;
    using System.Linq;

    using PrimeControl.WebAPI.Contratos;
    using PrimeControl.Core.Modelo;

    public static class ContatoParser
    {
       
        public static ContratoRetornoContato Converter(Contato contato)
        {
            return new ContratoRetornoContato
            {
                Identificador = contato.Identificador,
                Telefone = contato.Telefone,
                ClientePessoaFisicaIdentificador = contato.ClientePessoaFisicaIdentificador
            };
        }

        public static Contato Converter(ContratoRetornoContato contratoRetornoContato)
        {
            return new Contato
            {
                Identificador = contratoRetornoContato.Identificador,
                ClientePessoaFisicaIdentificador = contratoRetornoContato.ClientePessoaFisicaIdentificador,
                Telefone = contratoRetornoContato.Telefone
            };
        }

        public static IEnumerable<ContratoRetornoContato> Converter(IEnumerable<Contato> contatos)
        {
            return contatos.Select(contato => Converter(contato));
        }
    }
}