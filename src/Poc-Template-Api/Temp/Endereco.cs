using System;
using System.Collections.Generic;

#nullable disable

namespace Poc_Template_Api.Temp
{
    public partial class Endereco
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public int UsuarioId { get; set; }
        public bool Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? ModificadoEm { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
