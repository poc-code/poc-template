using Bogus;
using Poc_Template_Domain.Entities;
using System;

namespace Poc_Template_Core_Test.Mock
{
    public static class UsuarioMock
    {
        public static Faker<Usuario> Fake => new Faker<Usuario>()
            .CustomInstantiator(x => new Usuario
            {
                Id = x.IndexFaker + 1,
                Nome = x.Person.FullName,
                Email = x.Person.Email,
                PessoaId = 1,
                Ativo = true,
                CriadoEm = DateTime.Now
            });
    }
}
