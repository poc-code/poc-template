using System.ComponentModel.DataAnnotations;

namespace Poc_Template_Api.ViewModel
{
    public class AcessoViewModel
    {
        [Required(ErrorMessage = "Infome o nome de usuário")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Informe uma senha")]
        public string Password { get; set; }
    }
}
