using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

using Poc_Template_Api.Services;
using Poc_Template_Api.Services.Interface;
using Poc_Template_Domain.Interfaces.Repository;
using Poc_Template_Infra.Repository;

namespace Poc_Template_Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static void ConfigureIoC(
            this IServiceCollection services,
            IConfiguration Configuration)
        {
            AddServices(services);
            AddRepository(services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienterService>();
            services.AddScoped<IDiagnosticoAplicacaoService, DiagnosticoAplicacaoService>();
        }

        private static void AddRepository(IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}
