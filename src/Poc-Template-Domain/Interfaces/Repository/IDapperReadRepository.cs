using System.Threading.Tasks;

namespace Poc_Template_Domain.Interfaces.Repository
{
    public interface IDapperReadRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
    }
}
