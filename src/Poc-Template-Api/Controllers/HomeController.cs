using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poc_Template_Api.Services.Interface;
using Poc_Template_Api.ViewModel;
using System.Collections.Generic;

namespace Poc_Template_Api.Controllers
{
    /// <summary>
    /// Home
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/myclass")]
    public class HomeController : ControllerBase
    {

        private readonly IMyClassFatherService _service;

        public HomeController(IMyClassFatherService service)
        {
            _service = service;
        }

        /// <summary>
        /// Cliente por Id.
        /// </summary>
        /// <param name="customer">Parâmetro "id" do cliente.</param>
        /// <returns>Cliente.</returns>
        /// <response code="200">Sucesso.</response>
        /// <response code="204">Nenhum resultado encontrado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public ActionResult GetById([FromQuery] int id)
        {
            var customerVM = _service.GetById(id);

            if (customerVM == null)
            {
                return NotFound();
            }

            return Ok(customerVM);
        }

        /// <summary>
        /// Retorna uma lista de objetos
        /// </summary>
        /// <returns>Action Result</returns>
        /// <response code="200">Sucesso.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public ActionResult<List<MyClassFatherViewModel>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        /// <summary>Criação de cliente.</summary>
        /// <remarks>Implementação sem validação</remarks>
        /// <param name="myClassFather">Parâmetro "cliente".</param>
        /// <returns>Cliente criado.</returns>
        /// <response code="201">Sucesso.</response>
        /// <response code="400">Falha na requisição.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public ActionResult<MyClassFatherViewModel> Post([FromBody] MyClassFatherViewModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var model = _service.Add(request);
                return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
            }
            catch (System.Exception)
            {
                return BadRequest(new { message = "Não foi possível criar a Cidade."});
            }
        }
    }
}
