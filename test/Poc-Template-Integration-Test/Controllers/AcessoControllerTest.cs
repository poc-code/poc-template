using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Poc_Template_Api;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Poc_Template_Integration_Test.Controllers
{
    public class AcessoControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;

        public AcessoControllerTest(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateClient();

        }

        [Fact]
        public async void Post_Sucess()
        {
            var stream = string.Empty;

           var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", "johndoe"),
                new KeyValuePair<string, string>("password", "senha1234")
            });

            var response = await _httpClient.PostAsync("/api/v1/acesso", formContent);
            if (response.Content is object)
            {
                stream = response.Content.ReadAsStringAsync().Result;
            }
            stream.Should().Contain("ProcessTime");//verifica se no json de retorno possui o parametro "endereco"
            response.StatusCode.Should().Equals(HttpStatusCode.OK);
        }
    }
}
