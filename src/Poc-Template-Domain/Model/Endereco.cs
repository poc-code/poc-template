using System.Collections.Generic;

namespace Poc_Template_Domain.Model
{
    public class Endereco
    {
        protected Endereco()
        {
            Clientes = new HashSet<Cliente>();
        }

        public Endereco(string cep)
        {
            CEP = cep;
        }

        public int Id { get; private set; }
        public string CEP { get; private set; }

        public ICollection<Cliente> Clientes { get; private set; }
    }
}
