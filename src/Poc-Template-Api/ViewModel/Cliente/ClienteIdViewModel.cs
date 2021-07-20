using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Poc_Template_Api.ViewModel.Customer
{
    public class ClienteIdViewModel
    {
        public ClienteIdViewModel() { }

        public ClienteIdViewModel(int id)
        {
            Id = id;
        }

        [FromRoute(Name = "id")]
        [Required(ErrorMessage = "Id é obrigatório")]
        public int Id { get; set; }
    }
}
