using Bmg.Desafio.Core.Application.DTO.Http.Models.Responses;
using Microsoft.Extensions.DependencyInjection;
using Ent = Bmg.Desafio.Proposta.Domain.Aggregates.PropostaAgg.Entities;
using Bmg.Desafio.Proposta.Enumerations;
using Bmg.Desafio.CrossCutting.Infra.Log.Contexts;
using Microsoft.AspNetCore.Http;
using Bmg.Desafio.Core.Application.DTO.Extensions;

namespace Bmg.Desafio.Proposta.Domain.Aggregates.PropostaAgg.Commands.Handlers;

public partial class PropostaCommandHandler
{
    // Define regras de criação: garantir UserId do contexto e status inicial.
    public override async Task<DomainResponse> OnCreateAsync(Ent.Proposta entity)
    {
        var httpContext = this._serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
        var userId = int.Parse(httpContext.User.GetUserId());

        entity.UserId = userId;

        return DomainResponse.Ok();
    }

    public override async Task<DomainResponse> OnUpdateAsync(Ent.Proposta entity, Ent.Proposta entityAfter)
    {
        // Transições permitidas: EmAnalise -> Aprovada | Rejeitada; Ajuste de valores somente EmAnalise.
        if (entity.Status != entityAfter.Status)
        {
            switch (entityAfter.Status)
            {
                case PropostaStatus.Aprovada:
                    try { entity.Aprovar(); } catch (Exception ex) { return DomainResponse.Error(ex.Message); }
                    break;
                case PropostaStatus.Rejeitada:
                    try { entity.Rejeitar(entityAfter.MotivoRejeicao ?? "Motivo não informado"); } catch (Exception ex) { return DomainResponse.Error(ex.Message); }
                    break;
                default:
                    return DomainResponse.Error("Transição de status inválida");
            }
        }

        entity.UpdatedAt = DateTime.Now;

        // Ajuste de valor cobertura se fornecido e ainda Em Análise
        if (entity.Status == PropostaStatus.EmAnalise && entityAfter.ValorCobertura > 0 && entity.ValorCobertura != entityAfter.ValorCobertura)
        {
            try { entity.DefinirValores(0, entityAfter.ValorCobertura); } catch (Exception ex) { return DomainResponse.Error(ex.Message); }
        }

        return DomainResponse.Ok();
    }
}
