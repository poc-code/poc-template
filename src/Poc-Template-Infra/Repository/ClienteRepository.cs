using Dapper;
using Poc_Template_Domain.Entities;
using Poc_Template_Domain.Extensions;
using Poc_Template_Domain.Interfaces.Repository;
using Poc_Template_Infra.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poc_Template_Infra.Repository
{
    public class ClienteRepository : EntityBaseRepository<Cliente>, IClienteRepository
    {
        private readonly DapperContext _dapperContext;
        public ClienteRepository(
            EntityContext context,
            DapperContext dapperContext
        ) : base(context)
        {
            _dapperContext = dapperContext;
        }


        public async Task<IEnumerable<Cliente>> BuscarTodosAsync()
        {
            var query = $"{SqlExtensionFunction.SelectQuery<Cliente>()} " +
            $"Where Ativo = 1";
            var result = await _dapperContext
                .DapperConnection.QueryAsync<Cliente>(query);
            return result;
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            var query = $"{SqlExtensionFunction.SelectQueryFirst<Cliente>()} " +
                $"Where Id = @Id  And Ativo = 1";
            var result = await _dapperContext
                .DapperConnection.QueryFirstAsync<Cliente>(query, new { Id = id });
            return result;
        }
    }
}
