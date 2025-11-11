        
        
namespace Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Commands.Handlers {
    using MediatR;
    using Core.Domain.Aggregates.CommonAgg.Commands.Handles;
    using Core.Domain.Aggregates.CommonAgg.Entities;
    public class BaseContratacaoAggCommandHandler<T> : BaseCommandHandler<T> where T : IEntity {public BaseContratacaoAggCommandHandler(IServiceProvider provider,IMediator mediator):base(mediator, provider){}}
}

