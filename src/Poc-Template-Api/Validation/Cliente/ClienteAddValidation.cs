using FluentValidation;
using Poc_Template_Api.ViewModel.Customer;
using Poc_Template_Domain.Interfaces.Repository;

namespace Poc_Template_Api.Validation.Cliente
{
    public class ClienteAddValidation : AbstractValidator<ClienteViewModel>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        
        public ClienteAddValidation(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;

            RuleFor(x => x.UsuarioId)
                .GreaterThanOrEqualTo(0)
                .WithMessage(x => "Informe o Id do usuário.");

            RuleFor(x => x)
                .Must(ValidarUsuario)
                .WithMessage(x => "Usuário não encontrado");
        }

        private bool ValidarUsuario(ClienteViewModel vm)
        {
            return _usuarioRepository.GetByIdAsync(vm.UsuarioId).Result is not null;
        }
    }
}
