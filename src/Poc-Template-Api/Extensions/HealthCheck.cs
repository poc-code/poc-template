using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Poc_Template_Api.Health;
using System.Diagnostics.CodeAnalysis;

namespace Poc_Template_Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class HealthCheck
    {
        public static void AddHealthcheckConfigurations(this IServiceCollection services, IConfiguration Configuration)
        {
            if (PlatformServices.Default.Application.ApplicationName != "testhost")
            {
                services.AddHealthChecksUI(setupSettings: setup =>
                {
                }).AddInMemoryStorage();

                services.AddHealthChecks()
                    .AddProcessAllocatedMemoryHealthCheck(500 * 1024 * 1024, "Process Memory", tags: new[] { "self" })
                    .AddPrivateMemoryHealthCheck(1500 * 1024 * 1024, "Private memory", tags: new[] { "self" })
                    .AddCheck<HealthCheckViaCep>("ViaCEP", tags: new[] { "services" });
            }
        }
    }
}
