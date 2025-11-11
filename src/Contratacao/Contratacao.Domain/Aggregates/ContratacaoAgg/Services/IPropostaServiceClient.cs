using Bmg.Desafio.Core.Application.DTO.Http.Models.Responses;
using Bmg.Desafio.Proposta.Application.DTO.Aggregates.PropostaAgg.Requests;

namespace Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Services
{
    public interface IPropostaServiceClient
    {
        Task<GetHttpResponseDTO<PropostaDTO>> GetPropostaAsync(string propostaId, CancellationToken cancellationToken = default);
        Task<bool> MarcarComoContratadaAsync(string propostaId, CancellationToken cancellationToken = default);
    }
}
