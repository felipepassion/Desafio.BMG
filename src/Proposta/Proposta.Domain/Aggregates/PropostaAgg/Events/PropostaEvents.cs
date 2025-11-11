
using Bmg.Desafio.Core.Domain.Aggregates.CommonAgg.Events;
using Bmg.Desafio.CrossCutting.Infra.Log.Contexts;

namespace Bmg.Desafio.Proposta.Domain.Aggregates.PropostaAgg.Events;
using Entities;

public partial class PropostaCreatedEvent : BaseEvent
{
    public PropostaCreatedEvent(ILogRequestContext ctx, Proposta data) 
        : base(ctx, data) { }
}
public partial class PropostaDeletedEvent : BaseEvent
{
    public PropostaDeletedEvent(ILogRequestContext ctx, Proposta data) 
        : base(ctx, data) { }
}
public partial class PropostaDeletedRangeEvent : BaseEvent
{
    public PropostaDeletedRangeEvent(ILogRequestContext ctx, IEnumerable<Proposta> data) 
        : base(ctx, data) { }
}
public partial class PropostaActivatedEvent : BaseEvent
{
    public PropostaActivatedEvent(ILogRequestContext ctx, Proposta data) 
        : base(ctx, data) { }
}
public partial class PropostaUpdatedEvent : BaseEvent
{
    public PropostaUpdatedEvent(ILogRequestContext ctx, Proposta data) 
        : base(ctx, data) { }
}
public partial class PropostaUpdatedRangeEvent : BaseEvent
{
    public PropostaUpdatedRangeEvent(ILogRequestContext ctx, IEnumerable<Proposta> data) 
        : base(ctx, data) { }
}
public partial class PropostaDeactivatedEvent : BaseEvent
{
    public PropostaDeactivatedEvent(ILogRequestContext ctx, Proposta data) 
        : base(ctx, data) { }
}
