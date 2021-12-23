using Microsoft.AspNetCore.Mvc;
using Poc_Template_Api.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Poc_Template_Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/myclass")]
    public class HomeController : ControllerBase
    {

        private List<MyClassFatherViewModel> ListObject = new List<MyClassFatherViewModel>
        {
            new MyClassFatherViewModel(1, "John", new MyClassChildViewModel(1,"Doe",18)),
            new MyClassFatherViewModel(2, "Mary", new MyClassChildViewModel(1,"Stwart",20))
        };

        /// <summary>
        /// Cliente por Id.
        /// </summary>
        /// <param name="customer">Parâmetro "id" do cliente.</param>
        /// <returns>Cliente.</returns>
        [HttpGet("{id}")]
        public ActionResult GetById([FromQuery] int id)
        {
            var customerVM = ListObject.FirstOrDefault(x => x.Id == id);

            if (customerVM == null)
            {
                return NotFound();
            }

            return Ok(customerVM);
        }

        /// <summary>
        /// Criação de cliente.
        /// </summary>
        /// <param name="myClassFather">Parâmetro "cliente".</param>
        /// <returns>Cliente criado.</returns>
        [HttpPost]
        public ActionResult<MyClassFatherViewModel> Post([FromBody] MyClassFatherViewModel request)
        {
            ListObject.Add(request);
            int index = ListObject.IndexOf(request);
            return Created(nameof(GetById), index);
        }
    }
}
