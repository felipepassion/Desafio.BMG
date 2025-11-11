        
        
namespace Bmg.Desafio.Proposta.Domain.Aggregates.PropostaAgg.Commands.Handlers {
    using MediatR;
    using Core.Domain.Aggregates.CommonAgg.Commands.Handles;
    using Core.Domain.Aggregates.CommonAgg.Entities;
    public class BasePropostaAggCommandHandler<T> : BaseCommandHandler<T> where T : IEntity {public BasePropostaAggCommandHandler(IServiceProvider provider,IMediator mediator):base(mediator, provider){}}
}

