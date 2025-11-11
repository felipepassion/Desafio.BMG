
namespace Bmg.Desafio.Users.Domain.Aggregates.UsersAgg.Events.Handlers;

using MediatR;
using CrossCutting.Infra.Log.Providers;
using Core.Domain.Aggregates.CommonAgg.Events.Handles;

public partial class UserEventHandler : BaseEventHandler,
    INotificationHandler<UserCreatedEvent>,
    INotificationHandler<UserDeletedEvent>,
    INotificationHandler<UserUpdatedEvent>,
    INotificationHandler<UserActivatedEvent>,
    INotificationHandler<UserDeactivatedEvent>{
    public UserEventHandler(ILogProvider logProvider, IServiceProvider serviceProvider):base(logProvider, serviceProvider){}
    public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken){PublishLog(notification);}
    public async Task Handle(UserDeletedEvent notification, CancellationToken cancellationToken){PublishLog(notification);}
    public async Task Handle(UserActivatedEvent notification, CancellationToken cancellationToken){PublishLog(notification);}
    public async Task Handle(UserUpdatedEvent notification, CancellationToken cancellationToken){PublishLog(notification);}
    public async Task Handle(UserDeactivatedEvent notification, CancellationToken cancellationToken){PublishLog(notification);}
}
