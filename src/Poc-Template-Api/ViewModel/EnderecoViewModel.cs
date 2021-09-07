using System;

namespace Poc_Template_Api.ViewModel
{
    public class EnderecoViewModel
    {
        public int Id { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public int PessoaId { get; set; }
        public bool? Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? ModificadoEm { get; set; }
    }
}
