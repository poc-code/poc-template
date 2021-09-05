using Moq;
using Poc_Template_Infra.Context;
using Poc_Template_Infra.Repository;
using Xunit;

namespace Poc_Template_Integration_Test.Repository
{
    public class ClienteRepositoryTest
    {
        private ClienteRepository _repository;
        private Mock<EntityContext> _entityContext;
        private Mock<DapperContext> _dapperContext;

        public ClienteRepositoryTest()
        {
            _entityContext = new Mock<EntityContext>();
            _dapperContext = new Mock<DapperContext>();

            _repository = new ClienteRepository(_entityContext.Object, _dapperContext.Object);
        }

        [Fact]
        public void BuscarEnderecoPorIdAsync()
        {

        }
    }
}
