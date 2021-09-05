using Poc_Template_Domain.Extensions;
using System;

namespace Poc_Template_Domain.Entities
{
    [QueryTable("Endereco")]
    public class Endereco
    {
        [QueryField("Id")]
        public int Id { get; set; }
        [QueryField("CEP")]
        public string CEP { get; set; }
        [QueryField("Logradouro")]
        public string Logradouro { get; set; }
        [QueryField("Complemento")]
        public string Complemento { get; set; }
        [QueryField("Bairro")]
        public string Bairro { get; set; }
        [QueryField("Localidade")]
        public string Localidade { get; set; }
        [QueryField("UF")]
        public string UF { get; set; }
        [QueryField("PessoaId")]
        public int PessoaId { get; set; }
        [QueryField("Ativo")]
        public bool? Ativo { get; set; }
        [QueryField("CriadoEm")]
        public DateTime CriadoEm { get; set; }
        [QueryField("ModificadoEm")]
        public DateTime? ModificadoEm { get; set; }
    }
}
