
using Bmg.Desafio.Core.Domain.Aggregates.CommonAgg.Events;
using Bmg.Desafio.CrossCutting.Infra.Log.Contexts;

namespace Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Events;
using Entities;

public partial class ContratoCreatedEvent : BaseEvent
{
    public ContratoCreatedEvent(ILogRequestContext ctx, Contrato data) 
        : base(ctx, data) { }
}
public partial class ContratoDeletedEvent : BaseEvent
{
    public ContratoDeletedEvent(ILogRequestContext ctx, Contrato data) 
        : base(ctx, data) { }
}
public partial class ContratoDeletedRangeEvent : BaseEvent
{
    public ContratoDeletedRangeEvent(ILogRequestContext ctx, IEnumerable<Contrato> data) 
        : base(ctx, data) { }
}
public partial class ContratoActivatedEvent : BaseEvent
{
    public ContratoActivatedEvent(ILogRequestContext ctx, Contrato data) 
        : base(ctx, data) { }
}
public partial class ContratoUpdatedEvent : BaseEvent
{
    public ContratoUpdatedEvent(ILogRequestContext ctx, Contrato data) 
        : base(ctx, data) { }
}
public partial class ContratoUpdatedRangeEvent : BaseEvent
{
    public ContratoUpdatedRangeEvent(ILogRequestContext ctx, IEnumerable<Contrato> data) 
        : base(ctx, data) { }
}
public partial class ContratoDeactivatedEvent : BaseEvent
{
    public ContratoDeactivatedEvent(ILogRequestContext ctx, Contrato data) 
        : base(ctx, data) { }
}
