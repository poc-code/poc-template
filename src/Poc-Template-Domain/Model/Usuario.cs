using System;

namespace Poc_Template_Domain.Model
{
    public class Usuario : DadosComuns
    {
        public int Id { get; init; }
        public string Nome { get; init; }
        public string Perfil { get; init; }
        
    }
}
