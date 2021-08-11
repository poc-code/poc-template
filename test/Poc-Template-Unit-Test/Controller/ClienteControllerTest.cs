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
            var viewmodel = ClienteMock.ClienteEnderecoViewModelFaker.Generate(3);

            _service.Setup(x => x.BuscarTodosAsync()).ReturnsAsync(viewmodel);

            var controller = new ClienteController(_service.Object);
            var data = await controller.GetAll();
            var actionValue = Assert.IsType<OkObjectResult>(data.Result);

            Assert.IsAssignableFrom<object>(actionValue.Value);
        }

        [Fact]
        public async Task GetById_SuccessTest()
        {
            var viewmodel = ClienteMock.ClienteEnderecoViewModelFaker.Generate();
            var returnService = ClienteMock.ClienteEnderecoViewModelFaker.Generate();

            _service.Setup(x => x.BuscarEnderecoPorIdAsync(It.IsAny<ClienteIdViewModel>()))
                .ReturnsAsync(returnService);

            var controller = new ClienteController(_service.Object);
            var data = await controller.GetById(new ClienteIdViewModel(viewmodel.Id));
            var actionValue = Assert.IsType<OkObjectResult>(data.Result);

            Assert.IsAssignableFrom<ClienteEnderecoViewModel>(actionValue.Value);
        }

        [Fact]
        public async Task GetById_NotFoundTest()
        {
            var viewmodel = ClienteMock.ClienteEnderecoViewModelFaker.Generate();

            var controller = new ClienteController(_service.Object);
            var data = await controller.GetById(new ClienteIdViewModel(viewmodel.Id));
            var actionValue = Assert.IsType<NotFoundResult>(data.Result);
        }

        [Fact]
        public async Task GetByNome_SuccessTest()
        {
            var viewmodel = ClienteMock.ClienteEnderecoViewModelFaker.Generate();
            var returnService = ClienteMock.ClienteEnderecoViewModelFaker.Generate();

            _service.Setup(x => x.BuscarEnderecoPorNomeAsync(It.IsAny<ClienteNomeViewModel>()))
                .ReturnsAsync(returnService);

            var controller = new ClienteController(_service.Object);
            var data = await controller.GetByName(new ClienteNomeViewModel(viewmodel.Nome));
            var actionValue = Assert.IsType<OkObjectResult>(data.Result);

            Assert.IsAssignableFrom<ClienteEnderecoViewModel>(actionValue.Value);
        }

        [Fact]
        public async Task GetByNOme_NotFoundTest()
        {
            var viewmodel = ClienteMock.ClienteEnderecoViewModelFaker.Generate();

            var controller = new ClienteController(_service.Object);
            var data = await controller.GetByName(new ClienteNomeViewModel(viewmodel.Nome));
            var actionValue = Assert.IsType<NotFoundResult>(data.Result);
        }

        [Fact]
        public async Task Post_SuccessTest()
        {
            var viewmodel = ClienteMock.ClienteViewModelFaker.Generate();
            _service.Setup(x => x.AdicionarAsync(It.IsAny<ClienteViewModel>()));

            var controller = new ClienteController(_service.Object);
            var data = await controller.PostCustomer(new ClienteViewModel(viewmodel.Id, viewmodel.EnderecoId, viewmodel.Nome));
            Assert.IsType<CreatedResult>(data.Result);
        }

        [Fact]
        public async Task Put_SuccessTest()
        {
            var viewmodel = ClienteMock.ClienteViewModelFaker.Generate();
            _service.Setup(x => x.AlterarAsync(It.IsAny<ClienteViewModel>()));
            _service.Setup(x => x.BuscarPorIdAsync(It.IsAny<ClienteIdViewModel>())).ReturnsAsync(viewmodel);

            var controller = new ClienteController(_service.Object);
            var data = await controller.PutCustomer(viewmodel.Id, new ClienteViewModel(viewmodel.Id, viewmodel.EnderecoId, viewmodel.Nome));
            Assert.IsType<NoContentResult>(data);
        }

        [Fact]
        public async Task Put_BadRequestTest()
        {
            var viewmodel = ClienteMock.ClienteViewModelFaker.Generate();
            _service.Setup(x => x.AlterarAsync(It.IsAny<ClienteViewModel>()));

            var controller = new ClienteController(_service.Object);
            var data = await controller.PutCustomer(viewmodel.Id + 1, new ClienteViewModel(viewmodel.Id, viewmodel.EnderecoId, viewmodel.Nome));
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async Task PutNotFoundTest()
        {
            var viewmodel = ClienteMock.ClienteViewModelFaker.Generate();
            _service.Setup(x => x.AlterarAsync(It.IsAny<ClienteViewModel>()));

            var controller = new ClienteController(_service.Object);
            var data = await controller.PutCustomer(viewmodel.Id, new ClienteViewModel(viewmodel.Id, viewmodel.EnderecoId, viewmodel.Nome));
            Assert.IsType<NotFoundResult>(data);
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
