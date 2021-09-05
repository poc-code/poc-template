using Poc_Template_Domain.Extensions;
using System;

#nullable disable

namespace Poc_Template_Domain.Entities
{
    [QueryTable("Cliente")]
    public partial class Cliente
    {
        [QueryField("Id")]
        public int Id { get; set; }
        [QueryField("Nome")]
        public string Nome { get; set; }
        [QueryField("EnderecoId")]
        public int EnderecoId { get; set; }
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
