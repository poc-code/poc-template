using Dapper;
using Poc_Template_Domain.Entities;
using Poc_Template_Domain.Extensions;
using Poc_Template_Domain.Interfaces.Repository;
using Poc_Template_Infra.Context;
using System.Threading.Tasks;

namespace Poc_Template_Infra.Repository
{
    public class UsuarioRepository : EntityBaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly DapperContext _dapperContext;
        public UsuarioRepository(
            EntityContext context,
            DapperContext dapperContext
        ) : base(context)
        {
            _dapperContext = dapperContext;
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            var query = $"{SqlExtensionFunction.SelectQueryFirst<Usuario>()} Where Id = @Id";
            return await _dapperContext.DapperConnection.QueryFirstAsync<Usuario>(query, new { Id = id });
        }
    }
}
