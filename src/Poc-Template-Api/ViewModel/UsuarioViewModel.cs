using System;

namespace Poc_Template_Api.ViewModel
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int PessoaId { get; set; }
        public bool? Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? ModificadoEm { get; set; }
    }
}
