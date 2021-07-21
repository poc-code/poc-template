using Poc_Template_Domain.Interfaces;
using Poc_Template_Domain.Model.Services;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Poc_Template_Infra.Services
{
    public class ViaCEPService : IViaCEPService
    {
        private readonly HttpClient _httpClient;

        public ViaCEPService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ViaCEP> GetByCEPAsync(string cep)
        {
            ViaCEP data = null;
            var response = await _httpClient.GetAsync($"{cep}/json",HttpCompletionOption.ResponseContentRead);
            response.EnsureSuccessStatusCode();
            if (response.Content is object)
            {
                var stream = await response.Content.ReadAsStringAsync();
                data = JsonSerializer.Deserialize<ViaCEP>(stream);
            }

            return data;
        }
    }
}
