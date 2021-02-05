namespace PrimeControl.WebAPI.Contratos
{
    using PrimeControl.Core.Modelo;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// DTO para endpoints de cliente pessoa juridica
    /// </summary>
    [DataContract]
    public class ContratoRetornoClientePessoaJuridica
    {
        
        [DataMember(Name = "identificador")]
        public int Identificador { get; set; }

        [DataMember(Name = "nomeFantasia")]
        public string NomeFantasia { get; set; }

        [DataMember(Name = "cnpj")]
        public string CNPJ { get; set; }

        [DataMember(Name = "uf")]
        public string UF { get; set; }

        [DataMember(Name = "instituicaoFinanceira")]
        public string InstituicaoFinanceira { get; set; }

    }
}