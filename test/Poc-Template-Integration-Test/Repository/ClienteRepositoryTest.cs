using Moq;
using Poc_Template_Core_Test.Mock;
using Poc_Template_Domain.Entities;
using Poc_Template_Infra.Context;
using Poc_Template_Infra.Repository;
using Xunit;

namespace Poc_Template_Integration_Test.Repository
{
    public class ClienteRepositoryTest : BaseRepositoryTest<Cliente>
    {
        private ClienteRepository _repository;
        private Mock<EntityContext> _entityContext;
        private Mock<DapperContext> _dapperContext;

        public ClienteRepositoryTest() : base(ClienteMock.ClienteFaker.Generate(10))
        {
            _entityContext = new Mock<EntityContext>();
            _dapperContext = new Mock<DapperContext>();

            _repository = new ClienteRepository(_entityContext.Object, _dapperContext.Object);
        }

        [Fact]
        public void Crud_Success_Test()
        {
            _repository.Add(FirstData);
            var IsSave = UnitOfWorkMock.Commit();

            _repository.Update(FirstData);
            var IsUpdate = UnitOfWorkMock.Commit();

            _repository.Remove(FirstData);
            var IsRemove = UnitOfWorkMock.Commit();

            Assert.Equal(1, IsSave);
            Assert.Equal(1, IsUpdate);
            Assert.Equal(1, IsRemove);
        }
    }
}
