using System;
using System.Collections.Generic;

namespace PrimeControl.Core.Modelo
{
    /// <summary>
    /// Modelo de domínio que representa um Cliente Pessoa Fisica
    /// </summary>
    public class ClientePessoaFisica : Cliente
    {

        /// <summary>
        /// Obtém ou define o nome do cliente.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define o CPF do cliente.
        /// </summary>
        public string CPF { get; set; }

        /// <summary>
        /// Obtém ou define a data de cadastro do cliente.
        /// </summary>
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Obtém ou define os telefones do cliente.
        /// </summary>
        public ICollection<Contato> Contatos { get; set; }

        public virtual void AddContato(Contato contato)
        {
            this.Contatos.Add(contato);
        }

    }
}