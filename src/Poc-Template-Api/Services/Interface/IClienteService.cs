using Poc_Template_Api.ViewModel.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poc_Template_Api.Services.Interface
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteViewModel>> BuscarTodosAsync();
        Task<ClienteViewModel> BuscarPorIdAsync(ClienteIdViewModel customerVM);
        Task<ClienteViewModel> AdicionarAsync(ClienteViewModel customerVM);
        Task<ClienteViewModel> AlterarAsync(ClienteViewModel customerVM);
        Task RemoverAsync(ClienteViewModel customerVM);
    }
}
