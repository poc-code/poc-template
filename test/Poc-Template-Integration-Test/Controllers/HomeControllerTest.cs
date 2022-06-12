using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Poc_Template_Api;
using Poc_Template_Api.Services.Interface;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Poc_Template_Integration_Test.Controllers
{
    public class HomeControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        private readonly Mock<IMyClassFatherService> _serviceMock;

        public HomeControllerTest(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task GetById__HttpStatusCodeOkTest()
        {
            var id = 1;
            var stream = string.Empty;
            var response = await _httpClient.GetAsync($"/api/v1/myclass/{id}", HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            if (response.Content is object)
            {
                stream = response.Content.ReadAsStringAsync().Result;
            }
            stream.Should().Contain("ProcessTime");//verifica se no json de retorno possui o parametro "endereco"
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
