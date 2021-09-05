using Poc_Template_Domain.Entities;

namespace Poc_Template_Domain.Interfaces.Repository
{
    public interface IPerfilRepository : IEntityBaseRepository<Perfil>,
        IDapperReadRepository<Perfil>
    {
    }
}
