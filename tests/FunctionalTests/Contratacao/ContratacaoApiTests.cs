using System.Net;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using FunctionalTests.TestUtils;

namespace FunctionalTests.Contratacao
{
    public class TestApiFactory : WebApplicationFactory<global::Bmg.Desafio.Contratacao.Api.Program> { }

    [Collection("Contratacao")]
    public class ContratacaoApiTests : IClassFixture<TestApiFactory>
    {
        private readonly HttpClient _client;

        public ContratacaoApiTests(TestApiFactory factory)
        {
            _client = factory.WithWebHostBuilder(_ => { }).CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost:5003")
            });
            // Attach bearer token from first user
            AuthTokenHelper.AttachBearerAsync(_client).GetAwaiter().GetResult();
        }

        [Fact]
        public async Task GetContratos_ShouldReturnOk()
        {
            var response = await _client.GetAsync("/api/Contrato/search?page=0&size=1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
