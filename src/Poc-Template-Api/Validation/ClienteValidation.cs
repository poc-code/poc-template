using FluentValidation;
using Poc_Template_Api.ViewModel.Customer;

namespace Poc_Template_Api.Validation
{
    public class ClienteValidation : AbstractValidator<ClienteViewModel>
    {
        public ClienteValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id é um campo obrigatório.");
        }
    }
}
