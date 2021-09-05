using System;
using System.ComponentModel.DataAnnotations;

namespace Poc_Template_Domain.Model
{
    public class Cliente
    {
        public Cliente() { }

        public Cliente(int id, int enderecoId, string nome)
        {
            Id = id;
            EnderecoId = enderecoId;
            Nome = nome;
        }

        public Cliente(int enderecoId, string name)
        {
            EnderecoId = enderecoId;
            Nome = name;
        }

        [Key]
        public int Id { get; private set; }
        public int EnderecoId { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public Endereco Endereco { get; private set; }
    }
}
