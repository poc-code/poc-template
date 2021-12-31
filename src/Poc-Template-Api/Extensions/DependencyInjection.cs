using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

using Poc_Template_Api.Services;
using Poc_Template_Api.Services.Interface;
using Poc_Template_Domain.Interfaces.Repository;
using Poc_Template_Infra.Repository;
using Poc_Template_Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using Poc_Template_Domain.Interfaces.Services;
using Poc_Template_Infra.UoW;
using Poc_Template_Domain.Interfaces.Notifications;
using Poc_Template_Domain.Notifications;

namespace Poc_Template_Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static void ConfigureIoC(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            AddServices(services);
            AddRepository(services);
            AddInfraConfigurations(services, configuration);
        }

        private static void AddInfraConfigurations(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<EntityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("db")));

            services.AddScoped<IDbConnection>(conn => new SqlConnection(Configuration.GetConnectionString("db")));
            services.AddScoped<DapperContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void AddServices(IServiceCollection services)
        {
            #region Domain
            services.AddScoped<IDomainNotification, DomainNotification>();
            #endregion
            services.AddScoped<IAcessoService, AcessoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IDiagnosticoAplicacaoService, DiagnosticoAplicacaoService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IPerfilService, PerfilService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IMyClassFatherService, MyClassFatherService>();
        }

        private static void AddRepository(IServiceCollection services)
        {
            services.AddScoped<IAcessoRepository, AcessoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
