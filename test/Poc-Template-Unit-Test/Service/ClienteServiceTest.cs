using AutoMapper;
using FluentAssertions;
using Moq;
using Poc_Template_Api.AutoMapper;
using Poc_Template_Api.Services;
using Poc_Template_Api.ViewModel.Customer;
using Poc_Template_Core_Test.Mock;
using Poc_Template_Domain.Interfaces;
using Poc_Template_Domain.Interfaces.Repository;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Poc_Template_Unit_Test.Service
{
    public class ClienteServiceTest
    {

        private readonly Mock<IClienteRepository> _repository;
        private readonly Mock<IViaCEPService> _viaCepService;

        private readonly IMapper _mapper;

        public ClienteServiceTest()
        {

            _repository = new Mock<IClienteRepository>();
            _viaCepService = new Mock<IViaCEPService>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfiles()));
            _mapper = new Mapper(config);

            //Arrange
            var clientesendereco = ClienteMock.ClienteEnderecoFaker.Generate(3);
            _repository.Setup(x => x.BuscarTodosAsync()).ReturnsAsync(clientesendereco);
            _repository.Setup(x => x.BuscarEnderecoPorIdAsync(It.IsAny<int>())).ReturnsAsync(clientesendereco.FirstOrDefault());
            _repository.Setup(x => x.BuscarPorNomeAsync(It.IsAny<string>())).ReturnsAsync(clientesendereco.FirstOrDefault());

            var clientes = ClienteMock.ClienteFaker.Generate(3);
            _repository.Setup(x => x.BuscarPorIdAsync(It.IsAny<int>())).ReturnsAsync(clientes.FirstOrDefault());

            var viacep = ViaCEPMock.Faker.Generate();
            _viaCepService.Setup(x => x.GetByCEPAsync(It.IsAny<string>())).ReturnsAsync(viacep);
        }

        [Fact]
        public async Task buscar_todos_cliente_enderecoAsync()
        {
            var service = new ClienteService(_repository.Object, _viaCepService.Object, _mapper);
            var teste = await service.BuscarTodosAsync();

            teste.Should().NotBeNull();
        }

        [Fact]
        public async Task buscar_cliente_endereco_por_id_async()
        {
            var service = new ClienteService(_repository.Object, _viaCepService.Object, _mapper);
            var teste = await service.BuscarEnderecoPorIdAsync(new ClienteIdViewModel(1));

            teste.Should().NotBeNull();
        }

        [Fact]
        public async Task buscar_cliente_por_id_async()
        {
            var service = new ClienteService(_repository.Object, _viaCepService.Object, _mapper);
            var teste = await service.BuscarPorIdAsync(new ClienteIdViewModel(1));

            teste.Should().NotBeNull();
        }

        [Fact]
        public async Task buscar_cliente_por_nome_async()
        {
            var service = new ClienteService(_repository.Object, _viaCepService.Object, _mapper);
            var teste = await service.BuscarEnderecoPorNomeAsync(new ClienteNomeViewModel(It.IsAny<string>()));

            teste.Should().NotBeNull().And.BeOfType<ClienteEnderecoViewModel>();
        }
    }
}
