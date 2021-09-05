using System.Threading.Tasks;

namespace Poc_Template_Api.Services.Interface
{
    public interface IAcessoService
    {
        Task<string> BuscarAutorizacao(string nomeusuario, string senha);
    }
}
