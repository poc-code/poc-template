using Dapper;
using Poc_Template_Domain.Entities;
using Poc_Template_Domain.Extensions;
using Poc_Template_Domain.Interfaces.Repository;
using Poc_Template_Infra.Context;
using System.Threading.Tasks;

namespace Poc_Template_Infra.Repository
{
    public class AcessoRepository : EntityBaseRepository<Acesso>, IAcessoRepository
    {
        private readonly DapperContext _dapperContext;
        public AcessoRepository(
            EntityContext context,
            DapperContext dapperContext
        ) : base(context)
        {
            _dapperContext = dapperContext;
        }

        public async Task<Acesso> Autorizar(Acesso data)
        {
            try
            {
                var query = $"{SqlExtensionFunction.SelectQueryFirst<Acesso>()} " +
                $"Where Username = @NomeUsuario And Password = @Senha";
                var acesso = await _dapperContext.DapperConnection.QueryFirstOrDefaultAsync<Acesso>(query, new { NomeUsuario = data.Username, Senha = data.Password });

                var queryusuario = $"{SqlExtensionFunction.SelectQueryFirst<Usuario>()} " +
                    $"Where Id = @UsuarioId";
                acesso.Usuario = await _dapperContext.DapperConnection
                    .QueryFirstAsync<Usuario>(queryusuario, new { UsuarioId = acesso.UsuarioId });

                var queryPerfil = $"{SqlExtensionFunction.SelectQueryFirst<Perfil>()} " +
                    $"Where Id = @PerfilId";
                acesso.Perfil = await _dapperContext.DapperConnection.QueryFirstOrDefaultAsync<Perfil>(queryPerfil, new { PerfilId = acesso.PerfilId });
                
                return acesso;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Acesso> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
