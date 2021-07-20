using Poc_Template_Domain.Dapper;
using Poc_Template_Domain.Interfaces.Repository;
using Poc_Template_Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poc_Template_Infra.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private List<ClienteEndereco> _clienteEndereco;
        private List<Cliente> _clientes;

        public ClienteRepository()
        {
            _clientes = new List<Cliente>
            {
                new Cliente(1,1,"Joao Silva"),
                new Cliente(2,1,"Maria Silva"),
            };

            _clienteEndereco = _clientes.Select(x => new ClienteEndereco(x.Id, 1, x.Name, x.DateCreated, "70150900")).ToList();
        }

        public async Task<ClienteEndereco> BuscarEnderecoPorIdAsync(int id)
        {
            return await Task.FromResult(_clienteEndereco.FirstOrDefault(x => x.Id == id));
        }

        public async Task<IEnumerable<ClienteEndereco>> BuscarTodosAsync()
        {
            return await Task.FromResult(_clienteEndereco.ToList());
        }

        public async Task<Cliente> BuscarPorIdAsync(int id)
        {
            return await Task.FromResult(_clientes.FirstOrDefault(x => x.Id == id));
        }

        public async Task<ClienteEndereco> BuscarPorNomeAsync(string name)
        {
            return await Task.FromResult(_clienteEndereco.FirstOrDefault(x => x.Nome == name));
        }

        public async Task<Cliente> AdicionarAsync(Cliente cliente)
        {
            Task<Cliente> tarefa = Task.Run(() => {
                var id = _clientes.Max(x => x.Id) + 1;
                
                var addcliente = new Cliente(id, cliente.AddressId, cliente.Name);
               
                _clientes.Add(addcliente);
                
                return _clientes.FirstOrDefault(x => x.Id == id);
            });

            return await tarefa;
        }

        public async Task<Cliente> AlterarAsync(Cliente cliente)
        {
            Task<Cliente> tarefa = Task.Run(() =>
            {
                var busca = _clientes.FirstOrDefault(x => x.Id == cliente.Id);
                if (busca.Id > 0)
                {
                    busca.AddressId = cliente.AddressId;
                    busca.Name = cliente.Name;
                }

                return busca;
            });

            return await tarefa;
        }

        public async Task<Cliente> RemoverAsync(Cliente cliente)
        {
            Task<Cliente> tarefa = Task.Run(() =>
            {
                var busca = _clientes.FirstOrDefault(x => x.Id == cliente.Id);
                if (busca.Id > 0) 
                    _clientes.Remove(busca);

                return busca;
            });
            return await tarefa;
        }
    }
}
