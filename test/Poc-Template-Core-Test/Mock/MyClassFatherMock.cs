using Bogus;
using Poc_Template_Api.ViewModel;

namespace Poc_Template_Core_Test.Mock
{
    public static class MyClassFatherMock
    {
        public static Faker<MyClassFatherViewModel> Fake =>
            new Faker<MyClassFatherViewModel>()
            .CustomInstantiator(x => new MyClassFatherViewModel(
                id: x.IndexFaker + 1,
                nome: x.Person.FirstName,
                child: new MyClassChildViewModel(x.IndexFaker + 1, x.Person.LastName,x.Random.Int(18,99))
                )
            );
    }
}
