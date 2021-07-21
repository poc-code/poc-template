using AutoBogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Poc_Template_Api;
using Poc_Template_Api.ViewModel.Customer;
using Poc_Template_Core_Test.Mock;
using Poc_Template_Domain.Dapper;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Poc_Template_Integration_Test.Controllers
{
    public class ClienteControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        private readonly IAutoFaker _autoFaker;

        public ClienteControllerTest(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateClient();
            _autoFaker = AutoFaker.Create();
        }

        [Fact]
        public async Task BuscarTodos_HttpStatusCodeOkTestAsync()
        {
            var stream = string.Empty;
            var response = await _httpClient.GetAsync("/api/v1/clientes",HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            if (response.Content is object)
            {
                stream = response.Content.ReadAsStringAsync().Result;
            }
            stream.Should().Contain("endereco");//verifica se no json de retorno possui o parametro "endereco"
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task BuscarPorId_HttpStatusCodeOkTestAsync()
        {
            var id = 1;

            var response = await _httpClient.GetAsync($"/api/v1/clientes/{id}");
            var jsonString = response.Content.ReadAsStringAsync().Result;
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var objeto = JsonSerializer.Deserialize<ClienteEnderecoViewModel>(jsonString, options);
            objeto.Should().BeAssignableTo<ClienteEnderecoViewModel>();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Post_HttpStatusCodeCreateTestAsync()
        {
            var Cliente = _autoFaker.Generate<ClienteEndereco>();
            var param = new StringContent(JsonSerializer.Serialize(Cliente), Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync("/api/v1/clientes", param);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task Put_HttpStatusCodeNoContentTestAsync()
        {
            var id = 1;
            var Cliente = ClienteMock.ClienteViewModelFaker.Generate();
            Cliente.Id = id;

            var response = await _httpClient.PutAsync($"/api/v1/clientes/{id}", new StringContent(JsonSerializer.Serialize(Cliente), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task Delete_HttpStatusCodeNoContentTestAsync()
        {
            var id = 1;
            var response = await _httpClient.DeleteAsync($"/api/v1/clientes/{id}");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
