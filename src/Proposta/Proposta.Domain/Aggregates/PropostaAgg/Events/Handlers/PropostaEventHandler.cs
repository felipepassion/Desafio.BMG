
namespace Bmg.Desafio.Proposta.Domain.Aggregates.PropostaAgg.Events.Handlers;

using MediatR;
using CrossCutting.Infra.Log.Providers;
using Core.Domain.Aggregates.CommonAgg.Events.Handles;

public partial class PropostaEventHandler : BaseEventHandler,
    INotificationHandler<PropostaCreatedEvent>,
    INotificationHandler<PropostaDeletedEvent>,
    INotificationHandler<PropostaUpdatedEvent>,
    INotificationHandler<PropostaActivatedEvent>,
    INotificationHandler<PropostaDeactivatedEvent>{
    public PropostaEventHandler(ILogProvider logProvider, IServiceProvider serviceProvider):base(logProvider, serviceProvider){}
    public async Task Handle(PropostaCreatedEvent notification, CancellationToken cancellationToken){PublishLog(notification);}
    public async Task Handle(PropostaDeletedEvent notification, CancellationToken cancellationToken){PublishLog(notification);}
    public async Task Handle(PropostaActivatedEvent notification, CancellationToken cancellationToken){PublishLog(notification);}
    public async Task Handle(PropostaUpdatedEvent notification, CancellationToken cancellationToken){PublishLog(notification);}
    public async Task Handle(PropostaDeactivatedEvent notification, CancellationToken cancellationToken){PublishLog(notification);}
}
