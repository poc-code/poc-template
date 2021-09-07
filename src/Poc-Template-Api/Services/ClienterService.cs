using AutoMapper;
using Poc_Template_Api.Services.Interface;
using Poc_Template_Api.Validation;
using Poc_Template_Api.Validation.Cliente;
using Poc_Template_Api.ViewModel.Customer;
using Poc_Template_Domain.Entities;
using Poc_Template_Domain.Interfaces.Notifications;
using Poc_Template_Domain.Interfaces.Repository;
using Poc_Template_Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poc_Template_Api.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainNotification _domainNotification;
        private readonly IMapper _mapper;

        public ClienteService(
            IClienteRepository clienteRepository,
            IUsuarioRepository usuarioRepository,
            IDomainNotification domainNotification, 
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _usuarioRepository = usuarioRepository;
            _domainNotification = domainNotification;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteViewModel>> BuscarTodosAsync()
        {
            var clientes = _mapper
                .Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.BuscarTodosAsync());

            return clientes;
        }

        public async Task<ClienteViewModel> BuscarPorIdAsync(ClienteIdViewModel vm)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.GetByIdAsync(vm.Id));
        }

        public async Task<ClienteViewModel> AdicionarAsync(ClienteViewModel vm)
        {
            var validacao = new ClienteAddValidation(_usuarioRepository).Validate(vm);
            if (!validacao.IsValid)
            {
                _domainNotification.AddNotifications(validacao);
                return null;
            }

            var cliente = _mapper.Map<Cliente>(vm);
            _clienteRepository.Add(cliente);
            _unitOfWork.Commit();
            var result = _mapper.Map<ClienteViewModel>(cliente);
            return result;
        }

        public async Task<ClienteViewModel> AlterarAsync(ClienteViewModel vm)
        {
            var validacao = new ClienteValidation().Validate(vm);
            if (!validacao.IsValid)
            {
                _domainNotification.AddNotifications(validacao);
                return null;
            }

            var cliente = _mapper.Map<Cliente>(vm);
            _clienteRepository.Update(cliente);
            _unitOfWork.Commit();
            var result = _mapper.Map<ClienteViewModel>(cliente);
            return result;
        }

        public async Task RemoverAsync(ClienteViewModel vm)
        {
            var validacao = new ClienteValidation().Validate(vm);
            if (!validacao.IsValid)
            {
                _domainNotification.AddNotifications(validacao);
            }

            var cliente = _mapper.Map<Cliente>(await _clienteRepository.GetByIdAsync(vm.Id));
            cliente.Ativo = false;
            cliente.ModificadoEm = System.DateTime.Now;
            _clienteRepository.Update(cliente);
            _unitOfWork.Commit();
        }
    }
}
