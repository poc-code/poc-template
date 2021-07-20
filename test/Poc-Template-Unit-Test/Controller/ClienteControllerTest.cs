using Microsoft.AspNetCore.Mvc;
using Moq;
using Poc_Template_Api.Controllers;
using Poc_Template_Api.Services.Interface;
using Poc_Template_Core_Test.Mock;
using System.Threading.Tasks;
using Xunit;

namespace Poc_Template_Unit_Test.Controller
{
    public class ClienteControllerTest
    {
        private readonly Mock<IClienteService> _service;

        public ClienteControllerTest()
        {
            _service = new Mock<IClienteService>();
        }

        [Fact]
        public async Task GetAll_ReturnListCustomerDapperTest()
        {
            var viewmodel = ClienteMock.ClienteEnderecoViewModelFaker.Generate(3);

            _service.Setup(x => x.BuscarTodosAsync()).ReturnsAsync(viewmodel);

            var controller = new ClienteController(_service.Object);
            var data = await controller.GetAll();
            var actionValue = Assert.IsType<OkObjectResult>(data.Result);

            Assert.IsAssignableFrom<object>(actionValue.Value);
        }
    }
}
