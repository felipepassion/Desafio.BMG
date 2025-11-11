
using Bmg.Desafio.Core.Domain.Aggregates.CommonAgg.Events;
using Bmg.Desafio.CrossCutting.Infra.Log.Contexts;

namespace Bmg.Desafio.Users.Domain.Aggregates.UsersAgg.Events;
using Entities;

public partial class UserCreatedEvent : BaseEvent
{
    public UserCreatedEvent(ILogRequestContext ctx, User data) 
        : base(ctx, data) { }
}
public partial class UserDeletedEvent : BaseEvent
{
    public UserDeletedEvent(ILogRequestContext ctx, User data) 
        : base(ctx, data) { }
}
public partial class UserDeletedRangeEvent : BaseEvent
{
    public UserDeletedRangeEvent(ILogRequestContext ctx, IEnumerable<User> data) 
        : base(ctx, data) { }
}
public partial class UserActivatedEvent : BaseEvent
{
    public UserActivatedEvent(ILogRequestContext ctx, User data) 
        : base(ctx, data) { }
}
public partial class UserUpdatedEvent : BaseEvent
{
    public UserUpdatedEvent(ILogRequestContext ctx, User data) 
        : base(ctx, data) { }
}
public partial class UserUpdatedRangeEvent : BaseEvent
{
    public UserUpdatedRangeEvent(ILogRequestContext ctx, IEnumerable<User> data) 
        : base(ctx, data) { }
}
public partial class UserDeactivatedEvent : BaseEvent
{
    public UserDeactivatedEvent(ILogRequestContext ctx, User data) 
        : base(ctx, data) { }
}
