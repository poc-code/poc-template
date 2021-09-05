using System;
using System.Collections.Generic;

#nullable disable

namespace Poc_Template_Api.Temp
{
    public partial class Acesso
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UsuarioId { get; set; }
        public int PerfilId { get; set; }
        public bool Ativo { get; set; }
        public int? Hit { get; set; }
        public DateTime UltimoAcesso { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? ModificadoEm { get; set; }

        public virtual Perfil Perfil { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
