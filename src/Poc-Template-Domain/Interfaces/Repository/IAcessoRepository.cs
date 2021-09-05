using Poc_Template_Domain.Entities;
using System.Threading.Tasks;

namespace Poc_Template_Domain.Interfaces.Repository
{
    public interface IAcessoRepository : IEntityBaseRepository<Acesso>,
        IDapperReadRepository<Acesso>
    {
        Task<Acesso> Autorizar(Acesso data);
    }
}
