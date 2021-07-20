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
        public async Task BuscarTodos_HttpStatusCodeUnauthorizedTestAsync()
        {
            var response = await _httpClient.GetAsync("/api/v1/clientes");
            var valor = response.Content.ReadAsStringAsync().Result;
            valor.Should().Contain("endereco");//verifica se no json de retorno possui o parametro "endereco"
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task BuscarPorId_HttpStatusCodeUnauthorizedTestAsync()
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
        public async Task Post_HttpStatusCodeUnauthorizedTestAsync()
        {
            var Cliente = _autoFaker.Generate<ClienteEndereco>();
            var param = new StringContent(JsonSerializer.Serialize(Cliente), Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync("/api/v1/clientes", param);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task Put_HttpStatusCodeUnauthorizedTestAsync()
        {
            var id = 1;
            var Cliente = ClienteMock.ClienteViewModelFaker.Generate();
            Cliente.Id = id;

            var response = await _httpClient.PutAsync($"/api/v1/clientes/{id}", new StringContent(JsonSerializer.Serialize(Cliente), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task Delete_HttpStatusCodeUnauthorizedTestAsync()
        {
            var id = 1;
            var response = await _httpClient.DeleteAsync($"/api/v1/clientes/{id}");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
