
namespace PrimeControl.Core.Modelo
{
    public class Contato
    {

        /// <summary>
        /// Obtém ou define o identificador do contato.
        /// </summary>
        public int Identificador { get; set; }

        public string Telefone { get; set; }

        public int ClientePessoaFisicaIdentificador { get; set; }

        public ClientePessoaFisica ClientePessoaFisica { get; set; }
    }
}
