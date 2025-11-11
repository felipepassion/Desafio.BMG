using Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Services;
using Bmg.Desafio.Core.Application.DTO.Http.Models.Responses;
using Bmg.Desafio.Proposta.Application.DTO.Aggregates.PropostaAgg.Requests;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace Bmg.Desafio.Contratacao.Infra.IoC
{
    internal class PropostaServiceClient : IPropostaServiceClient
    {
        private readonly HttpClient _http;
        private readonly string _base;
        public PropostaServiceClient(IConfiguration configuration, IHttpClientFactory factory, IHttpContextAccessor httpContextAccessor)
        {
            _http = factory.CreateClient("PropostaService");
            _base = configuration.GetValue<string>("PropostaService:BaseUrl")?.TrimEnd('/') ?? "http://localhost:5002"; // default fallback

            var ctx = httpContextAccessor.HttpContext;
            if (ctx != null)
            {
                if (ctx.Request.Headers.TryGetValue("Authorization", out var authorization) && !string.IsNullOrWhiteSpace(authorization))
                {
                    if (AuthenticationHeaderValue.TryParse(authorization.ToString(), out var auth))
                    {
                        _http.DefaultRequestHeaders.Authorization = auth;
                    }
                }

                if (ctx.Request.Headers.TryGetValue("Cookie", out var cookie) && !string.IsNullOrWhiteSpace(cookie))
                {
                    if (!_http.DefaultRequestHeaders.Contains("Cookie"))
                        _http.DefaultRequestHeaders.Add("Cookie", cookie.ToString());
                }
            }
        }

        public async Task<GetHttpResponseDTO<PropostaDTO>> GetPropostaAsync(string propostaId, CancellationToken cancellationToken = default)
        {
            try
            {
                var resp = await _http.GetFromJsonAsync<GetHttpResponseDTO<PropostaDTO>>($"{_base}/api/Proposta/{propostaId}", cancellationToken);
                return resp;
            }
            catch(Exception ex) { return GetHttpResponseDTO.ErrorTyped<PropostaDTO>(ex.Message); }
        }

        public async Task<bool> MarcarComoContratadaAsync(string propostaId, CancellationToken cancellationToken = default)
        {
            try
            {
                var resp = await _http.PostAsync($"{_base}/api/Proposta", null, cancellationToken);
                return resp.IsSuccessStatusCode;
            }
            catch { return false; }
        }
    }
}
