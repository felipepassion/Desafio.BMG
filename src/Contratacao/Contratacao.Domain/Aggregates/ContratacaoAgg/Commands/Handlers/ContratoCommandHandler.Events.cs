using Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Entities;
using Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Services;
using Bmg.Desafio.Contratacao.Enumerations;
using Bmg.Desafio.Core.Application.DTO.Extensions;
using Bmg.Desafio.Core.Application.DTO.Http.Models.Responses;
using Bmg.Desafio.CrossCutting.Infra.Log.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Commands.Handlers;

public partial class ContratoCommandHandler
{
    public override async Task<DomainResponse> OnCreateAsync(Contrato entity)
    {
        var httpContext = this._serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;

        var propostaService = _serviceProvider.GetService<IPropostaServiceClient>();
        if (propostaService == null) return DomainResponse.Error("Serviço de Proposta não disponível");
        

        var propostaObj = await propostaService.GetPropostaAsync(entity.PropostaExternalId);
        if (propostaObj.StatusCode == HttpStatusCode.NotFound)
            return DomainResponse.Error("Proposta não encontrada");
        else if(propostaObj.Data.Status != Proposta.Enumerations.PropostaStatus.Aprovada)
            return DomainResponse.Error("Proposta não pode ser contratada (precisa estar aprovada)");
        else if (propostaObj.StatusCode != HttpStatusCode.OK)
            return DomainResponse.Error("Erro ao consultar Proposta");


        if (string.IsNullOrWhiteSpace(entity.NumeroContrato))
        {
            entity.GetType().GetProperty("NumeroContrato")?.SetValue(entity, $"CTR-{Guid.NewGuid().ToString()[..8].ToUpper()}");
        }

        entity.PropostaId = propostaObj.Data.Id.Value;
        entity.UserId = int.Parse(httpContext.User.GetUserId());

        return DomainResponse.Ok();
    }

    public override async Task<DomainResponse> OnUpdateAsync(Contrato entity, Contrato entityAfter)
    {
        if (entity.Status != entityAfter.Status)
        {
            switch (entityAfter.Status)
            {
                case ContratoStatus.Cancelado:
                    if (string.IsNullOrWhiteSpace(entityAfter.MotivoCancelamento)) return DomainResponse.Error("Motivo de cancelamento obrigatório");
                    try { entity.Cancelar(entityAfter.MotivoCancelamento); } catch (Exception ex) { return DomainResponse.Error(ex.Message); }
                    break;
                case ContratoStatus.Encerrado:
                    try { entity.Encerrar(); } catch (Exception ex) { return DomainResponse.Error(ex.Message); }
                    break;
                default:
                    return DomainResponse.Error("Transição de status inválida");
            }
        }
        return DomainResponse.Ok();
    }
}
