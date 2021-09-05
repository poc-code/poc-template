using AutoMapper;
using Poc_Template_Api.Services.Interface;
using Poc_Template_Api.ViewModel.Customer;
using Poc_Template_Domain.Interfaces;
using Poc_Template_Domain.Interfaces.Repository;
using Poc_Template_Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poc_Template_Api.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IViaCEPService _viaCEPService;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IViaCEPService viaCEPService, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _viaCEPService = viaCEPService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteEnderecoViewModel>> BuscarTodosAsync()
        {
            var customers = _mapper.Map<IEnumerable<ClienteEnderecoViewModel>>(await _clienteRepository.BuscarTodosAsync());

            foreach (var customer in customers)
            {
                var address = await _viaCEPService.GetByCEPAsync(customer.CEP);

                customer.Endereco.Id = customer.EnderecoId;
                customer.Endereco.Logradouro = address?.Logradouro;
                customer.Endereco.Complemento = address?.Complemento;
                customer.Endereco.Bairro = address?.Bairro;
                customer.Endereco.Localidade = address?.Localidade;
                customer.Endereco.UF = address?.UF;
            }

            return customers;
        }

        public async Task<ClienteViewModel> BuscarPorIdAsync(ClienteIdViewModel customerVM)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.BuscarPorIdAsync(customerVM.Id));
        }

        public async Task<ClienteEnderecoViewModel> BuscarEnderecoPorIdAsync(ClienteIdViewModel customerVM)
        {
            var customer = _mapper.Map<ClienteEnderecoViewModel>(await _clienteRepository.BuscarEnderecoPorIdAsync(customerVM.Id));

            if (customer != null)
            {
                var address = await _viaCEPService.GetByCEPAsync(customer.CEP);

                customer.Endereco.Id = customer.EnderecoId;
                customer.Endereco.Logradouro = address?.Logradouro;
                customer.Endereco.Complemento = address?.Complemento;
                customer.Endereco.Bairro = address?.Bairro;
                customer.Endereco.Localidade = address?.Localidade;
                customer.Endereco.UF = address?.UF;
            }

            return customer;
        }

        public async Task<ClienteEnderecoViewModel> BuscarEnderecoPorNomeAsync(ClienteNomeViewModel customerVM)
        {
            var customer = _mapper.Map<ClienteEnderecoViewModel>(await _clienteRepository.BuscarPorNomeAsync(customerVM.Nome));

            if (customer != null)
            {
                var address = await _viaCEPService.GetByCEPAsync(customer.CEP);

                customer.Endereco.Id = customer.EnderecoId;
                customer.Endereco.Logradouro = address?.Logradouro;
                customer.Endereco.Complemento = address?.Complemento;
                customer.Endereco.Bairro = address?.Bairro;
                customer.Endereco.Localidade = address?.Localidade;
                customer.Endereco.UF = address?.UF;
            }

            return customer;
        }

        public async Task<ClienteViewModel> AdicionarAsync(ClienteViewModel customerVM)
        {
            var result = await _clienteRepository.AdicionarAsync(_mapper.Map<Cliente>(customerVM));
            return _mapper.Map<ClienteViewModel>(result);
        }

        public async Task<ClienteViewModel> AlterarAsync(ClienteViewModel customerVM)
        {
            var result = await _clienteRepository.AlterarAsync(_mapper.Map<Cliente>(customerVM));
            return _mapper.Map<ClienteViewModel>(result);
        }

        public async Task RemoverAsync(ClienteViewModel customerVM)
        {
            await _clienteRepository.RemoverAsync(_mapper.Map<Cliente>(customerVM));
        }
    }
}
