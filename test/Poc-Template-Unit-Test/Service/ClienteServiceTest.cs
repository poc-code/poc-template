using AutoMapper;
using FluentAssertions;
using Moq;
using Poc_Template_Api.AutoMapper;
using Poc_Template_Api.Services;
using Poc_Template_Api.ViewModel.Customer;
using Poc_Template_Core_Test.Mock;
using Poc_Template_Domain.Interfaces;
using Poc_Template_Domain.Interfaces.Notifications;
using Poc_Template_Domain.Interfaces.Repository;
using Poc_Template_Domain.Interfaces.Services;
using System.Threading.Tasks;
using Xunit;

namespace Poc_Template_Unit_Test.Service
{
    public class ClienteServiceTest
    {

        private readonly Mock<IClienteRepository> _repository;
        private readonly Mock<IUsuarioRepository> _usuarioRepository;
        private readonly Mock<IDomainNotification> _domainNotification;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<IViaCEPService> _viaCepService;
        private readonly ClienteService _clienteService;

        private readonly IMapper _mapper;

        public ClienteServiceTest()
        {

            _repository = new Mock<IClienteRepository>();
            _usuarioRepository = new Mock<IUsuarioRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _domainNotification = new Mock<IDomainNotification>();
            _viaCepService = new Mock<IViaCEPService>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfiles()));
            _mapper = new Mapper(config);

            //Arrange
            var clientes = ClienteMock.ClienteFaker.Generate(3);

            _repository.Setup(x => x.BuscarTodosAsync()).ReturnsAsync(clientes);

            var viacep = ViaCEPMock.Faker.Generate();
            _viaCepService.Setup(x => x.GetByCEPAsync(It.IsAny<string>())).ReturnsAsync(viacep);

            _clienteService = new ClienteService(
                _repository.Object, 
                _usuarioRepository.Object,
                _domainNotification.Object,
                _unitOfWork.Object,
                _mapper);
        }

        [Fact]
        public async Task buscar_todos_cliente_enderecoAsync()
        {
            var service = new ClienteService(
                _repository.Object, 
                _usuarioRepository.Object,
                _domainNotification.Object,
                _unitOfWork.Object,
                _mapper);
            var teste = await service.BuscarTodosAsync();

            teste.Should().NotBeNull();
        }

        [Fact]
        public async Task buscar_cliente_endereco_por_id_async()
        {
            var teste = await _clienteService.BuscarPorIdAsync(new ClienteIdViewModel(1));

            teste.Should().NotBeNull();
        }

    }
}
