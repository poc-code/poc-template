using Poc_Template_Domain.Extensions;
using System;

#nullable disable

namespace Poc_Template_Domain.Entities
{
    [QueryTable("Perfil")]
    public partial class Perfil
    {
        [QueryField("Id")]
        public int Id { get; set; }
        [QueryField("Nome")]
        public string Nome { get; set; }
        [QueryField("Ativo")]
        public bool? Ativo { get; set; }
        [QueryField("CriadoEm")]
        public DateTime CriadoEm { get; set; }
        [QueryField("ModificadoEm")]
        public DateTime? ModificadoEm { get; set; }
    }
}
