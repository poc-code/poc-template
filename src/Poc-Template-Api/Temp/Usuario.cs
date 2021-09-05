using System;
using System.Collections.Generic;

#nullable disable

namespace Poc_Template_Api.Temp
{
    public partial class Usuario
    {
        public Usuario()
        {
            Acessos = new HashSet<Acesso>();
            Clientes = new HashSet<Cliente>();
            Enderecos = new HashSet<Endereco>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int PessoaId { get; set; }
        public bool Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? ModificadoEm { get; set; }

        public virtual ICollection<Acesso> Acessos { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
