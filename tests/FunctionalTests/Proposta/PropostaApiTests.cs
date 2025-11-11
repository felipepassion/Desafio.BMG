using System.Net;
using System.Net.Http.Json;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace FunctionalTests.Proposta
{
    public class TestApiFactory : WebApplicationFactory<global::Bmg.Desafio.Proposta.Api.Program> { }

    public class PropostaApiTests : IClassFixture<TestApiFactory>
    {
        private readonly HttpClient _client;

        public PropostaApiTests(TestApiFactory factory)
        {
            _client = factory.WithWebHostBuilder(_ => { }).CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost:5002")
            });
        }

        [Fact]
        public async Task GetPropostas_ShouldReturnOk()
        {
            var response = await _client.GetAsync("/api/Proposta/search?page=0&size=1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
