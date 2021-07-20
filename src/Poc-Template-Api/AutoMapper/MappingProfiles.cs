using Poc_Template_Api.ViewModel.Customer;
using Poc_Template_Domain.Dapper;
using Poc_Template_Domain.Model;
using System.Diagnostics.CodeAnalysis;
using AutoMapper;

namespace Poc_Template_Api.AutoMapper
{
    [ExcludeFromCodeCoverage]
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region Cliente

            CreateMap<ClienteEndereco, ClienteEnderecoViewModel>();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();

            #endregion
        }
    }
}
