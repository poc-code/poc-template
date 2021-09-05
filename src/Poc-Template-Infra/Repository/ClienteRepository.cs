using Dapper;
using Poc_Template_Domain.Dapper;
using Poc_Template_Domain.Extensions;
using Poc_Template_Domain.Interfaces.Repository;
using Poc_Template_Domain.Model;
using Poc_Template_Infra.Context;
using System;
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


        public async Task<ClienteEndereco> BuscarEnderecoPorIdAsync(int id)
        {
            var query = $"{SqlExtensionFunction.SelectQuery<Cliente>()} Where Id = @Id And Ativo = 1";
            var cliente = await _dapperContext.DapperConnection.QueryFirstOrDefaultAsync<Cliente>(query, new { Id = id });
            
            var result = new ClienteEndereco(cliente.Id, cliente.EnderecoId, cliente.Nome, cliente.CriadoEm, cliente.Endereco.CEP);
            return result;
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            var query = $"{SqlExtensionFunction.SelectQueryFirst<Cliente>()} Where Id = @Id And Ativo = 1";
            return await _dapperContext.DapperConnection.QueryFirstAsync<Cliente>(query, new { Id = id });
        }

        public async Task<IEnumerable<ClienteEndereco>> BuscarTodosAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> BuscarPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ClienteEndereco> BuscarPorNomeAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> AdicionarAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> AlterarAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> RemoverAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
