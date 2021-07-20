using System;

namespace Poc_Template_Domain.Model
{
    public class Cliente
    {
        public Cliente() { }

        public Cliente(int id, int enderecoId, string nome)
        {
            Id = id;
            AddressId = enderecoId;
            Name = nome;
        }

        public Cliente(int enderecoId, string name)
        {
            AddressId = enderecoId;
            Name = name;
        }

        public int Id { get; private set; }
        public int AddressId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; private set; }
        public bool Ativo { get; set; }
        public Endereco Address { get; private set; }
    }
}
