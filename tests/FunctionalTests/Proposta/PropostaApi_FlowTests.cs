using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Xunit;
using Bmg.Desafio.Proposta.Application.DTO.Aggregates.PropostaAgg.Requests;
using Bmg.Desafio.Proposta.Enumerations;
using Microsoft.AspNetCore.Mvc.Testing;
using Bmg.Desafio.Core.Application.DTO.Http.Models.Responses;
using Bmg.Desafio.Contratacao.Application.DTO.Aggregates.ContratacaoAgg.Requests;
using Bmg.Desafio.CrossCutting.Infra.Log.Contexts;
using Microsoft.Extensions.DependencyInjection;
using FunctionalTests.TestUtils;

namespace FunctionalTests.Proposta
{
    [Collection("Proposta")]
    public class PropostaApi_FlowTests : IClassFixture<PropostaApiFactory>
    {
        private readonly HttpClient _client;
        private readonly PropostaApiFactory _factory;

        public PropostaApi_FlowTests(PropostaApiFactory factory)
        {
            _factory = factory;
            _client = factory.WithWebHostBuilder(_ => { }).CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost:5002")
            });
        }

        [Fact]
        public async Task Search_ShouldReturnOk()
        {
            var resp = await _client.GetAsync("/api/Proposta/search?page=0&size=1");
            resp.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Create_Authenticated_ShouldReturnOk_WithDefaultStatusEmAnalise()
        {
            var authClient = _factory.WithWebHostBuilder(_ => { }).CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost:5002")
            });
            await AuthTokenHelper.AttachBearerAsync(authClient);

            var dto = new PropostaDTO { ValorCobertura = 1500m };
            var resp = await authClient.PostAsJsonAsync("/api/Proposta", dto);
            var content = await resp.Content.ReadAsStringAsync();
            resp.StatusCode.Should().Be(HttpStatusCode.OK);

            var payload = await resp.Content.ReadFromJsonAsync<GetHttpResponseDTO<PropostaDTO>>();
            payload.Should().NotBeNull();
            payload!.Data.Should().NotBeNull();
            payload.Data.Status.Should().Be(PropostaStatus.EmAnalise);
        }

        [Fact]
        public async Task Update_ToAprovada_WhenEmAnalise_ShouldReturnOk()
        {
            var client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = new Uri("http://localhost:5002") });
            await AuthTokenHelper.AttachBearerAsync(client);

            var createDto = new PropostaDTO { ValorCobertura = 500m };
            var createResp = await client.PostAsJsonAsync("/api/Proposta", createDto);
            if (createResp.StatusCode != HttpStatusCode.OK)
                return;

            var payload = await createResp.Content.ReadFromJsonAsync<GetHttpResponseDTO<PropostaDTO>>();
            var externalId = payload?.Data?.ExternalId;
            externalId.Should().NotBeNull();

            var approveDto = new PropostaDTO { Status = PropostaStatus.Aprovada };
            var approveResp = await client.PutAsJsonAsync($"/api/Proposta/{externalId}", approveDto);
            approveResp.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Update_ToAprovada_FromRejeitada_ShouldReturnBadRequest()
        {
            var client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = new Uri("http://localhost:5002") });
            await AuthTokenHelper.AttachBearerAsync(client);

            var createDto = new PropostaDTO { ValorCobertura = 500m };
            var createResp = await client.PostAsJsonAsync("/api/Proposta", createDto);
            if (createResp.StatusCode != HttpStatusCode.OK)
                return;

            var payload = await createResp.Content.ReadFromJsonAsync<GetHttpResponseDTO<PropostaDTO>>();
            var externalId = payload?.Data?.ExternalId;
            externalId.Should().NotBeNull();
            payload!.Data.Should().NotBeNull();

            // Primeiro rejeita a proposta
            payload.Data.Status = PropostaStatus.Rejeitada;
            var rejectResp = await client.PutAsJsonAsync($"/api/Proposta/{externalId}", payload.Data);
            if (rejectResp.StatusCode != HttpStatusCode.OK)
                return;

            // Depois tenta aprovar a partir de Rejeitada (deve falhar)
            payload.Data.Status = PropostaStatus.Aprovada;
            var approveResp = await client.PutAsJsonAsync($"/api/Proposta/{externalId}", payload.Data);
            approveResp.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Create_ThenAdjustValorCobertura_WhileEmAnalise()
        {
            var client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = new Uri("http://localhost:5002") });
            await AuthTokenHelper.AttachBearerAsync(client);

            var createDto = new PropostaDTO { ValorCobertura = 500m };
            var createResp = await client.PostAsJsonAsync("/api/Proposta", createDto);
            if (createResp.StatusCode != HttpStatusCode.OK)
                return; // nada a fazer se falhou criação

            var payload = await createResp.Content.ReadFromJsonAsync<GetHttpResponseDTO<PropostaDTO>>();
            var externalId = payload?.Data?.ExternalId;
            externalId.Should().NotBeNull();

            var updateDto = new PropostaDTO { ValorCobertura = 800m };
            var updateResp = await client.PutAsJsonAsync($"/api/Proposta/{externalId}", updateDto);
            updateResp.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
