using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http.Headers;
using Poc_Template_Domain.Interfaces;
using Poc_Template_Infra.Services;

namespace Poc_Template_Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class RegisterHttpClient
    {
        public static void AddHttpClients(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddHttpClient<IViaCEPService, ViaCEPService>((s, c) =>
            {
                c.BaseAddress = new Uri(Configuration["ViaCEP:Url"]);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }).AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.OrResult(response =>
                    (int)response.StatusCode == (int)HttpStatusCode.InternalServerError)
              .WaitAndRetryAsync(3, retry =>
                   TimeSpan.FromSeconds(Math.Pow(2, retry)) +
                   TimeSpan.FromMilliseconds(new Random().Next(0, 100))))
              .AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.CircuitBreakerAsync(
                   handledEventsAllowedBeforeBreaking: 3,
                   durationOfBreak: TimeSpan.FromSeconds(30)
            ));
        }
    }
}
