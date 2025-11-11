namespace Bmg.Desafio.Proposta.Domain.Aggregates.PropostaAgg.Commands;

using CrossCutting.Infra.Log.Contexts;
using Core.Domain.Aggregates.CommonAgg.Commands;
using Queries.Models; 
using Bmg.Desafio.Proposta.Application.DTO.Aggregates.PropostaAgg.Requests; 
    public partial class CreatePropostaCommand : BaseRequestableCommand<PropostaQueryModel, PropostaDTO>
    {
        public bool UpdateIfExists { get; set; }
        public CreatePropostaCommand(ILogRequestContext ctx, PropostaDTO data, bool updateIfExists = true, PropostaQueryModel query = null) 
            : base(ctx, query, data) { this.UpdateIfExists = updateIfExists; }
    }
    public partial class DeletePropostaCommand : BaseDeletionCommand<PropostaQueryModel>
    {
        public DeletePropostaCommand(ILogRequestContext ctx, PropostaQueryModel query, bool isLogicalDeletion = true)
            : base(ctx, query, isLogicalDeletion) { }
    }
      public partial class DeleteRangePropostaCommand : BaseDeletionCommand<PropostaQueryModel>
    {
        public DeleteRangePropostaCommand(ILogRequestContext ctx, PropostaQueryModel query, bool isLogicalDeletion = true)
            : base(ctx, query, isLogicalDeletion) { }
    }
    public partial class UpdateRangePropostaCommand : BaseRequestableRangeCommand<PropostaQueryModel, PropostaDTO>
    {
        public bool CreateIfNotExists { get; set; } = true;
        public UpdateRangePropostaCommand(ILogRequestContext ctx, Dictionary<PropostaQueryModel, PropostaDTO> query)
            : base(ctx, query) { }
        public UpdateRangePropostaCommand(ILogRequestContext ctx, PropostaQueryModel query, PropostaDTO data)
            : base(ctx, new Dictionary<PropostaQueryModel, PropostaDTO> { { query, data } }) { }
    }
    
    public partial class UpdatePropostaCommand : BaseRequestableCommand<PropostaQueryModel, PropostaDTO>
    {
        public bool CreateIfNotExists { get; set; } = true;
        public UpdatePropostaCommand(ILogRequestContext ctx, PropostaQueryModel query, PropostaDTO data, bool createIfNotExists = true)
            : base(ctx, query, data) { this.CreateIfNotExists = createIfNotExists; }
    }
    public partial class ActivePropostaCommand : PropostaSearchableCommand
    {
        public ActivePropostaCommand(ILogRequestContext ctx, PropostaQueryModel query)
            : base(ctx, query) { }
    }
    public partial class DeactivePropostaCommand : PropostaSearchableCommand
    {
        public DeactivePropostaCommand(ILogRequestContext ctx, PropostaQueryModel query)
            : base(ctx, query) { }
    }
    public class PropostaSearchableCommand : BaseSearchableCommand<PropostaQueryModel> {
        public PropostaSearchableCommand(ILogRequestContext ctx, PropostaQueryModel query)
            : base(ctx, query) { }
    }
