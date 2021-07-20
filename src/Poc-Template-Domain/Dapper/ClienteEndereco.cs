using System;

namespace Poc_Template_Domain.Dapper
{
    public class ClienteEndereco
    {
        public ClienteEndereco(int id, int enderecoId, string nome, DateTime dataCriacao, string cep)
        {
            Id = id;
            EnderecoId = enderecoId;
            Nome = nome;
            DataCriacao = dataCriacao;
            CEP = cep;
        }

        public int Id { get; set; }
        public int EnderecoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public string CEP { get; set; }
    }
}
