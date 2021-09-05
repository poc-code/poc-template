using Dapper;
using Poc_Template_Domain.Entities;
using Poc_Template_Domain.Extensions;
using Poc_Template_Domain.Interfaces.Repository;
using Poc_Template_Infra.Context;
using System.Threading.Tasks;

namespace Poc_Template_Infra.Repository
{
    public class EnderecoRepository : EntityBaseRepository<Endereco>, IEnderecoRepository
    {
        private readonly DapperContext _dapperContext;
        public EnderecoRepository(
            EntityContext context,
            DapperContext dapperContext
        ) : base(context)
        {
            _dapperContext = dapperContext;
        }

        public async Task<Endereco> GetByIdAsync(int id)
        {
            var query = $"{SqlExtensionFunction.SelectQueryFirst<Endereco>()} Where Id = @Id And Ativo = 1";
            return await _dapperContext.DapperConnection.QueryFirstAsync<Endereco>(query, new { Id = id });
        }
    }
}
