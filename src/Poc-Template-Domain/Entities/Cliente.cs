using Poc_Template_Domain.Extensions;
using System;
using System.ComponentModel.DataAnnotations.Schema;

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
        [QueryField("UsuarioId")]
        public int UsuarioId { get; set; }
        [QueryField("Ativo")]
        public bool? Ativo { get; set; }
        [QueryField("CriadoEm")]
        public DateTime CriadoEm { get; set; }
        [QueryField("ModificadoEm")]
        public DateTime? ModificadoEm { get; set; }
    }
}
