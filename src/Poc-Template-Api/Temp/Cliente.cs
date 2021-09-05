using System;
using System.Collections.Generic;

#nullable disable

namespace Poc_Template_Api.Temp
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public int UsuarioId { get; set; }
        public bool Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? ModificadoEm { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
