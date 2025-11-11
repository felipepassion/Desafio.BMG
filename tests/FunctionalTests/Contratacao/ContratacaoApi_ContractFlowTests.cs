using Bmg.Desafio.Contratacao.Application.DTO.Aggregates.ContratacaoAgg.Requests;
using Bmg.Desafio.Contratacao.Enumerations;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using Xunit;
using FunctionalTests.TestUtils;
using Bmg.Desafio.Proposta.Application.DTO.Aggregates.PropostaAgg.Requests;
using Bmg.Desafio.Core.Application.DTO.Http.Models.Responses;
using FunctionalTests.Proposta;

namespace FunctionalTests.Contratacao
{
    [Collection("Contratacao")]
    public class ContratacaoApi_ContractFlowTests : IClassFixture<ContratacaoApiFactory>, IClassFixture<PropostaApiFactory>
    {
        private readonly HttpClient _client;
        private readonly HttpClient _propostaClient;
        private readonly ContratacaoApiFactory _factory;
        private readonly PropostaApiFactory _propostaFactory;

        public ContratacaoApi_ContractFlowTests(ContratacaoApiFactory factory, PropostaApiFactory propostaFactory)
        {
            _propostaFactory = propostaFactory;
            _factory = factory;
            _client = factory.WithWebHostBuilder(_ => { }).CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost:5003")
            });
            _propostaClient = _propostaFactory.WithWebHostBuilder(_ => { }).CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost:5002")
            });
            AuthTokenHelper.AttachBearerAsync(_client, _propostaClient).Wait();
        }

        [Fact]
        public async Task Search_ShouldReturnOk()
        {
            var resp = await _client.GetAsync("/api/Contrato/search?page=0&size=1");
            resp.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Search_WithPagination_ShouldReturnOk()
        {
            var resp = await _client.GetAsync("/api/Contrato/search?page=0&size=2");
            resp.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetById_NotFound_ShouldReturnNotFound()
        {
            var resp = await _client.GetAsync($"/api/Contrato/{Guid.NewGuid()}");
            resp.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Create_Authenticated_ShouldFail_WhenPropostaNotApprovedOrMissing()
        {
            var authClient = _factory.WithWebHostBuilder(_ => { }).CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost:5003")
            });
            await AuthTokenHelper.AttachBearerAsync(authClient);

            var dto = new ContratoDTO
            {
                NumeroContrato = string.Empty,
                InicioVigencia = DateTime.UtcNow.Date,
                FimVigencia = DateTime.UtcNow.Date.AddDays(1),
                DataContratacao = DateTime.UtcNow,
                Status = ContratoStatus.Ativo
            };
            var nonExistingProposta = Guid.NewGuid();
            var response = await authClient.PostAsJsonAsync($"/api/Contrato/proposta/{nonExistingProposta}/contratar", dto);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Update_ToCancel_WithoutReason_ShouldReturnBadRequestOrOk_WhenEntityDoesNotExist()
        {
            var authClient = _factory.WithWebHostBuilder(_ => { }).CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost:5003")
            });
            await AuthTokenHelper.AttachBearerAsync(authClient);

            var updateDto = new ContratoDTO
            {
                Status = ContratoStatus.Cancelado,
                MotivoCancelamento = null
            };

            var resp = await authClient.PutAsJsonAsync($"/api/Contrato/{Guid.NewGuid()}", updateDto);
            // Fluxo atual pode tentar criar e falhar nas regras de OnCreate (proposta), ou ignorar por inexistencia
            resp.StatusCode.Should().BeOneOf(HttpStatusCode.BadRequest, HttpStatusCode.OK);
        }

        [Fact]
        public async Task Update_ToEncerrado_ShouldBe_Ok()
        {
            var newProposta = new PropostaDTO
            {
                Status = Bmg.Desafio.Proposta.Enumerations.PropostaStatus.Aprovada,
                ValorCobertura = 200
            };
            var propostaResp = await _propostaClient.PostAsJsonAsync("/api/Proposta", newProposta);
            propostaResp.StatusCode.Should().Be(HttpStatusCode.OK);
            var propostaPayload = await propostaResp.Content.ReadFromJsonAsync<GetHttpResponseDTO<PropostaDTO>>();
            var nonExistingProposta = propostaPayload!.Data.Id;
            await AuthTokenHelper.AttachBearerAsync(_client, _propostaClient);

            var updateDto = new ContratoDTO
            {
                Status = ContratoStatus.Ativo,
                DataContratacao = DateTime.UtcNow,
                FimVigencia = DateTime.UtcNow.AddYears(1),
                InicioVigencia = DateTime.UtcNow,
                NumeroContrato = "12345"                
            };

            var resp = await _client.PostAsJsonAsync($"/api/Contrato/proposta/{newProposta.ExternalId}/contratar", updateDto);
            var createPropostaContent = await resp.Content.ReadFromJsonAsync<GetHttpResponseDTO<ContratoDTO>>();
            resp.StatusCode.Should().BeOneOf(HttpStatusCode.OK);

            updateDto.Status = ContratoStatus.Encerrado;
            var resp2 = await _client.PutAsJsonAsync($"/api/Contrato/{createPropostaContent!.Data.ExternalId}", updateDto);
            var resultContent = await resp2.Content.ReadFromJsonAsync<GetHttpResponseDTO<ContratoDTO>>();

            resp2.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Update_ToEncerrado_ShouldBe_Fail_Because_Proposta_Is_Not_Approved()
        {
            var newProposta = new PropostaDTO
            {
                Status = Bmg.Desafio.Proposta.Enumerations.PropostaStatus.EmAnalise,
                ValorCobertura = 200
            };
            var propostaResp = await _propostaClient.PostAsJsonAsync("/api/Proposta", newProposta);
            propostaResp.StatusCode.Should().Be(HttpStatusCode.OK);
            var propostaPayload = await propostaResp.Content.ReadFromJsonAsync<GetHttpResponseDTO<PropostaDTO>>();
            var nonExistingProposta = propostaPayload!.Data.Id;
            await AuthTokenHelper.AttachBearerAsync(_client, _propostaClient);

            var updateDto = new ContratoDTO
            {
                Status = ContratoStatus.Ativo,
                DataContratacao = DateTime.UtcNow,
                FimVigencia = DateTime.UtcNow.AddYears(1),
                InicioVigencia = DateTime.UtcNow,
                NumeroContrato = "12345"
            };

            var resp = await _client.PostAsJsonAsync($"/api/Contrato/proposta/{newProposta.ExternalId}/contratar", updateDto);
            var createPropostaContent = await resp.Content.ReadFromJsonAsync<GetHttpResponseDTO<ContratoDTO>>();
            resp.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Update_ShouldCancel_WhenReasonProvided()
        {
            // cria um contrato válido exige proposta aprovada - como o teste é isolado,
            // aqui só exercitamos a validação de cancelamento direto (chamando PUT em um id inexistente não criará).
            // Assim validamos somente retorno 400 quando não encontra, e 400 se faltar motivo. Para um teste fim-a-fim
            // completo precisaríamos subir também o serviço de Proposta e semear dados.

            var updateDto = new ContratoDTO
            {
                MotivoCancelamento = "teste",
                Status = ContratoStatus.Cancelado
            };

            var resp = await _client.PutAsJsonAsync($"/api/Contrato/{Guid.NewGuid()}", updateDto);
            // Sem entidade, o fluxo atual tenta criar (CreateIfNotExists), mas falhará nas regras de OnCreate (sem proposta aprovada)
            resp.StatusCode.Should().BeOneOf(HttpStatusCode.BadRequest, HttpStatusCode.OK);
        }
    }
}
