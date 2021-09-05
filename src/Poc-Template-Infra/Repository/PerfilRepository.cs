using Dapper;
using Poc_Template_Domain.Entities;
using Poc_Template_Domain.Extensions;
using Poc_Template_Domain.Interfaces.Repository;
using Poc_Template_Infra.Context;
using System.Threading.Tasks;

namespace Poc_Template_Infra.Repository
{
    public class PerfilRepository : EntityBaseRepository<Perfil>, IPerfilRepository
    {
        private readonly DapperContext _dapperContext;
        public PerfilRepository(
            EntityContext context,
            DapperContext dapperContext
        ) : base(context)
        {
            _dapperContext = dapperContext;
        }

        public async Task<Perfil> GetByIdAsync(int id)
        {
            var query = $"{SqlExtensionFunction.SelectQueryFirst<Perfil>()} Where Id = @Id And Ativo = 1";
            return await _dapperContext.DapperConnection.QueryFirstAsync<Perfil>(query, new { Id = id });
        }
    }
}
