
namespace PrimeControl.Core.Modelo
{
    /// <summary>
    /// Modelo de domínio que representa um Cliente Pessoa Juridica
    /// </summary>
    public class ClientePessoaJuridica : Cliente
    {

        /// <summary>
        /// Obtém ou define a UF do cliente.
        /// </summary>
        public string UF { get; set; }

        /// <summary>
        /// Obtém ou define o nome fantasia do cliente.
        /// </summary>
        public string NomeFantasia { get; set; }

        /// <summary>
        /// Obtém ou define o CNPJ do cliente.
        /// </summary>
        public string CNPJ { get; set; }

    }
}