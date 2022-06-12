using FluentAssertions;
using Poc_Template_Core_Test.Mock;
using Poc_Template_Domain.Entities;
using Poc_Template_Infra.Repository;
using System.Threading.Tasks;
using Xunit;

namespace Poc_Template_Integration_Test.Repository
{
    public class UsuarioRepositoryTest : BaseRepositoryTest<Usuario>
    {
        private UsuarioRepository _repository;

        public UsuarioRepositoryTest() : base(UsuarioMock.Fake.Generate(10))
        {
            _repository = new UsuarioRepository(EntityContextMock, DapperContextMock);
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

        [Fact]
        public async Task GetByIdAsync_Sucesso()
        {
            var rs = await _repository.GetByIdAsync(1);
            rs.Should().NotBeNull().And.BeAssignableTo<Usuario>();
        }
    }
}
