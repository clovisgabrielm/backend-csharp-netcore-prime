namespace PrimeControl.WebAPI.Contratos
{
    using PrimeControl.Core.Modelo;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    [DataContract]
    public class ContratoRetornoContato
    {
        
        [DataMember(Name = "identificador")]
        public int Identificador { get; set; }

        [DataMember(Name = "telefone")]
        public string Telefone { get; set; }

        public int ClientePessoaFisicaIdentificador { get; set; }
    }
}