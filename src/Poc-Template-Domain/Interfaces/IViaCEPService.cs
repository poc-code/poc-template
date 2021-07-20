using Poc_Template_Domain.Model.Services;
using System.Threading.Tasks;

namespace Poc_Template_Domain.Interfaces
{
    public interface IViaCEPService
    {
        Task<ViaCEP> GetByCEPAsync(string cep);
    }
}
