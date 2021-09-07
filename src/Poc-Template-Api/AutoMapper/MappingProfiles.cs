using AutoMapper;
using Poc_Template_Api.ViewModel.Customer;
using Poc_Template_Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Poc_Template_Api.AutoMapper
{
    [ExcludeFromCodeCoverage]
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region Cliente

            CreateMap<Cliente, ClienteViewModel>().ReverseMap();

            #endregion
        }
    }
}
