using System;
using System.Collections.Generic;

#nullable disable

namespace Poc_Template_Api.Temp
{
    public partial class Perfil
    {
        public Perfil()
        {
            Acessos = new HashSet<Acesso>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? ModificadoEm { get; set; }

        public virtual ICollection<Acesso> Acessos { get; set; }
    }
}
