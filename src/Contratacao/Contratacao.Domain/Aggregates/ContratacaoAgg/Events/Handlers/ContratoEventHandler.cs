
namespace Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Events.Handlers;

using MediatR;
using CrossCutting.Infra.Log.Providers;
using Core.Domain.Aggregates.CommonAgg.Events.Handles;

public partial class ContratoEventHandler : BaseEventHandler,
    INotificationHandler<ContratoCreatedEvent>,
    INotificationHandler<ContratoDeletedEvent>,
    INotificationHandler<ContratoUpdatedEvent>,
    INotificationHandler<ContratoActivatedEvent>,
    INotificationHandler<ContratoDeactivatedEvent>{
    public ContratoEventHandler(ILogProvider logProvider, IServiceProvider serviceProvider):base(logProvider, serviceProvider){}
    public async Task Handle(ContratoCreatedEvent notification, CancellationToken cancellationToken){PublishLog(notification);}
    public async Task Handle(ContratoDeletedEvent notification, CancellationToken cancellationToken){PublishLog(notification);}
    public async Task Handle(ContratoActivatedEvent notification, CancellationToken cancellationToken){PublishLog(notification);}
    public async Task Handle(ContratoUpdatedEvent notification, CancellationToken cancellationToken){PublishLog(notification);}
    public async Task Handle(ContratoDeactivatedEvent notification, CancellationToken cancellationToken){PublishLog(notification);}
}
