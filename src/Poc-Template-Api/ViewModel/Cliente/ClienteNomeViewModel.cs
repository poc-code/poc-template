using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Poc_Template_Api.ViewModel.Customer
{
    public class ClienteNomeViewModel
    {
        public ClienteNomeViewModel() { }

        public ClienteNomeViewModel(string nome)
        {
            Nome = nome;
        }

        [FromRoute(Name = "name")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
    }
}
