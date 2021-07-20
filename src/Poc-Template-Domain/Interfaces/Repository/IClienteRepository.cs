using Poc_Template_Domain.Dapper;
using Poc_Template_Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poc_Template_Domain.Interfaces.Repository
{
    public interface IClienteRepository
    {
        Task<IEnumerable<ClienteEndereco>> BuscarTodosAsync();
        Task<ClienteEndereco> BuscarEnderecoPorIdAsync(int id);
        Task<Cliente> BuscarPorIdAsync(int id);
        Task<ClienteEndereco> BuscarPorNomeAsync(string name);
        Task<Cliente> AdicionarAsync(Cliente cliente);
        Task<Cliente> AlterarAsync(Cliente cliente);
        Task<Cliente> RemoverAsync(Cliente cliente);
    }
}
