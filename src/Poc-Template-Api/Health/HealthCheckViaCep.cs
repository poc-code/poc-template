using Microsoft.Extensions.Diagnostics.HealthChecks;
using Poc_Template_Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Poc_Template_Api.Health
{
    public class HealthCheckViaCep : IHealthCheck
    {
        private IViaCEPService _service;

        public HealthCheckViaCep(IViaCEPService service)
        {
            _service = service;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _service.GetByCEPAsync("70150900");

                if (result is null)
                {
                    return await Task.FromResult(
                        HealthCheckResult.Unhealthy($"ViaCep is unhealthy. zero results or null"));
                }

                return await Task.FromResult(
                        HealthCheckResult.Healthy($"ViaCep had a healthy result."));
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy(ex.Message);
            }
        }
    }
}
