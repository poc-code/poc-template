using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poc_Template_Api.Services.Interface;
using Poc_Template_Api.ViewModel.Customer;
using Poc_Template_Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poc_Template_Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService customerService)
        {
            _clienteService = customerService;
        }

        /// <summary>
        /// Lista de clientes.
        /// </summary>
        /// <returns>Clientes.</returns>
        /// <response code="200">Sucesso.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<ClienteViewModel>>> GetAll()
        {
            return Ok(await _clienteService.BuscarTodosAsync());
        }

        /// <summary>
        /// Cliente por Id.
        /// </summary>
        /// <param name="customer">Parâmetro "id" do cliente.</param>
        /// <returns>Cliente.</returns>
        /// <response code="200">Sucesso.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ClienteViewModel>> GetById([FromQuery] ClienteIdViewModel customer)
        {
            var customerVM = await _clienteService.BuscarPorIdAsync(customer);

            if (customerVM == null)
            {
                return NotFound();
            }

            return Ok(customerVM);
        }

        
        /// <summary>
        /// Criação de cliente.
        /// </summary>
        /// <param name="customer">Parâmetro "cliente".</param>
        /// <returns>Cliente criado.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ClienteViewModel>> PostCustomer([FromBody] ClienteViewModel customer)
        {
            return Created(nameof(GetById), await _clienteService.AdicionarAsync(customer));
        }

        /// <summary>
        /// Atualização de cliente.
        /// </summary>
        /// <param name="id">Parâmetro "id" do cliente.</param>
        /// <param name="customer">Parâmetro "cliente".</param>
        /// <returns>Cliente atualizado.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> PutCustomer(int id, [FromBody] ClienteViewModel customer)
        {
            if (customer == null || customer.Id != id)
            {
                return BadRequest();
            }

            var customerVM = await _clienteService.BuscarPorIdAsync(new ClienteIdViewModel(id));

            if (customerVM == null)
            {
                return NotFound();
            }

           await _clienteService.AlterarAsync(customer);

            return NoContent();
        }

        /// <summary>
        /// Exclusão de cliente.
        /// </summary>
        /// <param name="customer">Parâmetro "id" do cliente.</param>
        /// <returns>Cliente excluido.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCustomer([FromQuery] ClienteIdViewModel customer)
        {
            var customerVM = await _clienteService.BuscarPorIdAsync(customer);

            if (customerVM == null)
            {
                return NotFound();
            }

            await _clienteService.RemoverAsync(customerVM);

            return NoContent();
        }
    }
}
