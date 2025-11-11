        
        
namespace Bmg.Desafio.Users.Domain.Aggregates.UsersAgg.Commands.Handlers {
    using MediatR;
    using Core.Domain.Aggregates.CommonAgg.Commands.Handles;
    using Core.Domain.Aggregates.CommonAgg.Entities;
    public class BaseUsersAggCommandHandler<T> : BaseCommandHandler<T> where T : IEntity {public BaseUsersAggCommandHandler(IServiceProvider provider,IMediator mediator):base(mediator, provider){}}
}

