namespace PrimeControl.WebAPI.Contratos
{
    using PrimeControl.Core.Modelo;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// DTO para Endpoints de clientes PF
    /// </summary>
    [DataContract]
    public class ContratoRetornoClientePessoaFisica
    {
        
        [DataMember(Name = "identificador")]
        public int Identificador { get; set; }

        [DataMember(Name = "nome")]
        public string Nome { get; set; }

        [DataMember(Name = "cpf")]
        public string CPF { get; set; }

        [DataMember(Name = "dataCadastro")]
        public DateTime DataCadastro { get; set; }

        [DataMember(Name = "contatos")]
        public ICollection<Contato> Contatos { get; set; }

        public virtual void AddContato(Contato contato)
        {
            this.Contatos.Add(contato);
        }

        [DataMember(Name = "instituicaoFinanceira")]
        public string InstituicaoFinanceira { get; set; }
    }
}