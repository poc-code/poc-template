using Microsoft.AspNetCore.Mvc;
using Poc_Template_Api.Services.Interface;
using Poc_Template_Api.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poc_Template_Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/diagnostico")]
    public class DiagnosticoController : ControllerBase
    {
        private readonly IDiagnosticoAplicacaoService _service;

        public DiagnosticoController(IDiagnosticoAplicacaoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista de clientes.
        /// </summary>
        /// <returns>Clientes.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiagnosticoAplicacaoModel>>> Get()
        {
            return Ok(_service.ObterDiagnostico());
        }
    }
}
