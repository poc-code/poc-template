using Poc_Template_Domain.Extensions;
using System;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Poc_Template_Domain.Entities
{
    [QueryTable("Acesso")]
    public partial class Acesso
    {
        [QueryField("Id")]
        public int Id { get; set; }
        [QueryField("Username")]
        public string Username { get; set; }
        [QueryField("Password")]
        public string Password { get; set; }
        [QueryField("UsuarioId")]
        public int UsuarioId { get; set; }
        [QueryField("PerfilId")]
        public int PerfilId { get; set; }
        [QueryField("Ativo")]
        public bool? Ativo { get; set; }
        [QueryField("Hit")]
        public int? Hit { get; set; }
        [QueryField("UltimoAcesso")]
        public DateTime UltimoAcesso { get; set; }
        [QueryField("CriadoEm")]
        public DateTime CriadoEm { get; set; }
        [QueryField("ModificadoEm")]
        public DateTime? ModificadoEm { get; set; }

        [NotMapped]
        public Usuario Usuario { get; set; }
        
        [NotMapped]
        public Perfil Perfil { get; set; }
        
    }
}
