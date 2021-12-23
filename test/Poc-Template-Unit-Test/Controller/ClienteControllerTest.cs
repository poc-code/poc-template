using Microsoft.AspNetCore.Mvc;
using Moq;
using Poc_Template_Api.Controllers;
using Poc_Template_Api.Services.Interface;
using Poc_Template_Api.ViewModel.Customer;
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
            var viewmodel = ClienteMock.ClienteViewModelFaker.Generate(3);

            _service.Setup(x => x.BuscarTodosAsync()).ReturnsAsync(viewmodel);

            var controller = new ClienteController(_service.Object);
            var data = await controller.GetAll();
            var actionValue = Assert.IsType<OkObjectResult>(data.Result);

            Assert.IsAssignableFrom<object>(actionValue.Value);
        }


        [Fact]
        public async Task GetById_NotFoundTest()
        {
            var viewmodel = ClienteMock.ClienteViewModelFaker.Generate();

            var controller = new ClienteController(_service.Object);
            var data = await controller.GetById(new ClienteIdViewModel(viewmodel.Id));
            var actionValue = Assert.IsType<NotFoundResult>(data.Result);
        }

        [Fact]
        public async Task Delete_SuccessTest()
        {
            var viewmodel = ClienteMock.ClienteViewModelFaker.Generate();
            _service.Setup(x => x.RemoverAsync(It.IsAny<ClienteViewModel>()));
            _service.Setup(x => x.BuscarPorIdAsync(It.IsAny<ClienteIdViewModel>())).ReturnsAsync(viewmodel);

            var controller = new ClienteController(_service.Object);
            var data = await controller.DeleteCustomer(new ClienteIdViewModel(viewmodel.Id));
            Assert.IsType<NoContentResult>(data);
        }

        [Fact]
        public async Task Delete_BadRequestTest()
        {
            var viewmodel = ClienteMock.ClienteViewModelFaker.Generate();
            _service.Setup(x => x.RemoverAsync(It.IsAny<ClienteViewModel>()));

            var controller = new ClienteController(_service.Object);
            var data = await controller.DeleteCustomer(new ClienteIdViewModel(viewmodel.Id));
            Assert.IsType<NotFoundResult>(data);
        }
    }
}
