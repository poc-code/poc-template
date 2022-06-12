using Bogus;
using Poc_Template_Domain.Entities;
using System;

namespace Poc_Template_Core_Test.Mock
{
    public static class PerfilMock
    {
        public static Faker<Perfil> Fake => new Faker<Perfil>()
            .CustomInstantiator(x => new Perfil { 
                Id = x.IndexFaker + 1,
                Nome = x.Person.FullName,
                Ativo = true,
                CriadoEm = DateTime.Now
            });
    }
}
