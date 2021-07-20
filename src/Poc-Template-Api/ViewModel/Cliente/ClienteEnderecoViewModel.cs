using Poc_Template_Api.ViewModel.Address;
using System;

namespace Poc_Template_Api.ViewModel.Customer
{
    public class ClienteEnderecoViewModel
    {
        public ClienteEnderecoViewModel()
        {
            Endereco = new EnderecoViewModel();
        }

        public ClienteEnderecoViewModel(int id, int enderecoId, string nome, DateTime dataCriacao, string cep)
        {
            Id = id;
            EnderecoId = enderecoId;
            Nome = nome;
            DataCriacao = dataCriacao;
            CEP = cep;
            Endereco = new EnderecoViewModel();
        }

        public int Id { get; set; }
        public int EnderecoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public string CEP { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}
