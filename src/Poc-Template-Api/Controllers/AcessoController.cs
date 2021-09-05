using Microsoft.AspNetCore.Mvc;
using Poc_Template_Api.Services.Interface;
using Poc_Template_Api.ViewModel;
using System.Threading.Tasks;

namespace Poc_Template_Api.Controllers
{
    /// <summary>
    /// Reliza as tarefas de acesso ao sistema
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/acesso")]
    public class AcessoController : ControllerBase
    {
        private IAcessoService _service;

        public AcessoController(IAcessoService service)
        {
            _service = service;
        }
        /// <summary>
        /// Busca o token de autenticação do usuário
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] AcessoViewModel acesso )
        {
            var response = await _service.BuscarAutorizacao(acesso.Username, acesso.Password);
            return Ok(response);
        }
    }
}
