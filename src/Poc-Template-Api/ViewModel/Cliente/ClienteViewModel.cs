using Poc_Template_Api.ViewModel.Address;
using System;

namespace Poc_Template_Api.ViewModel.Customer
{
    public class ClienteViewModel
    {
        public ClienteViewModel() { }

        public ClienteViewModel(int id, int enderecoId, string nome)
        {
            Id = id;
            EnderecoId = enderecoId;
            Nome = nome;
        }

        public ClienteViewModel(int addressId, string name)
        {
            EnderecoId = addressId;
            Nome = name;
        }

        public int Id { get; set; }
        public int EnderecoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}
