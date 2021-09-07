using Poc_Template_Domain.Dapper;
using Poc_Template_Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poc_Template_Domain.Interfaces.Repository
{
    public interface IClienteRepository : IEntityBaseRepository<Cliente>,
        IDapperReadRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> BuscarTodosAsync();
    }
}
