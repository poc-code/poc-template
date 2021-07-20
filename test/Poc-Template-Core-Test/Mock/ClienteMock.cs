using Bogus;
using Poc_Template_Api.ViewModel.Customer;
using Poc_Template_Domain.Dapper;
using Poc_Template_Domain.Model;

namespace Poc_Template_Core_Test.Mock
{
    public static class ClienteMock
    {
        public static Faker<Cliente> ClienteFaker => new Faker<Cliente>()
            .CustomInstantiator(x => new Cliente(
                id: x.IndexFaker + 1, enderecoId: 1, nome: x.Person.FullName));

        public static Faker<ClienteViewModel> ClienteViewModelFaker => new Faker<ClienteViewModel>()
            .CustomInstantiator(x => new ClienteViewModel(
                id: x.IndexFaker + 1, enderecoId: 1, nome: x.Person.FullName));
         public static Faker<ClienteEnderecoViewModel> ClienteEnderecoViewModelFaker => new Faker<ClienteEnderecoViewModel>()
            .CustomInstantiator(x => new ClienteEnderecoViewModel(
                id: x.IndexFaker + 1, enderecoId: 1, nome: x.Person.FullName,dataCriacao: System.DateTime.Now, "72870221"));
        public static Faker<ClienteEndereco> ClienteEnderecoFaker => new Faker<ClienteEndereco>()
            .CustomInstantiator(x => new ClienteEndereco(
                id: x.IndexFaker + 1, enderecoId: 1, nome: x.Person.FullName,dataCriacao: System.DateTime.Now, "72870221"));


    }
}
