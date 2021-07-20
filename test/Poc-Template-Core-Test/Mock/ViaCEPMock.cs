using Bogus;
using Poc_Template_Domain.Model.Services;

namespace Poc_Template_Core_Test.Mock
{
    public static class ViaCEPMock
    {
        public static Faker<ViaCEP> Faker => new Faker<ViaCEP>()
            .CustomInstantiator(x => new ViaCEP { 
                CEP = x.Address.ZipCode(),
                Bairro = x.Address.CityPrefix(),
                Complemento = x.Address.Locale,
                Localidade = x.Address.Locale,
                Logradouro = x.Address.FullAddress(),
                UF = x.Address.CityPrefix()
            });
    }
}
