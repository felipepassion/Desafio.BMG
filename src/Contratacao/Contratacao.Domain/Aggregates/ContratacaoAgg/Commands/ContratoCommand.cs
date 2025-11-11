namespace Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Commands;

using CrossCutting.Infra.Log.Contexts;
using Core.Domain.Aggregates.CommonAgg.Commands;
using Queries.Models; 
using Bmg.Desafio.Contratacao.Application.DTO.Aggregates.ContratacaoAgg.Requests; 
    public partial class CreateContratoCommand : BaseRequestableCommand<ContratoQueryModel, ContratoDTO>
    {
        public bool UpdateIfExists { get; set; }
        public CreateContratoCommand(ILogRequestContext ctx, ContratoDTO data, bool updateIfExists = true, ContratoQueryModel query = null) 
            : base(ctx, query, data) { this.UpdateIfExists = updateIfExists; }
    }
    public partial class DeleteContratoCommand : BaseDeletionCommand<ContratoQueryModel>
    {
        public DeleteContratoCommand(ILogRequestContext ctx, ContratoQueryModel query, bool isLogicalDeletion = true)
            : base(ctx, query, isLogicalDeletion) { }
    }
      public partial class DeleteRangeContratoCommand : BaseDeletionCommand<ContratoQueryModel>
    {
        public DeleteRangeContratoCommand(ILogRequestContext ctx, ContratoQueryModel query, bool isLogicalDeletion = true)
            : base(ctx, query, isLogicalDeletion) { }
    }
    public partial class UpdateRangeContratoCommand : BaseRequestableRangeCommand<ContratoQueryModel, ContratoDTO>
    {
        public bool CreateIfNotExists { get; set; } = true;
        public UpdateRangeContratoCommand(ILogRequestContext ctx, Dictionary<ContratoQueryModel, ContratoDTO> query)
            : base(ctx, query) { }
        public UpdateRangeContratoCommand(ILogRequestContext ctx, ContratoQueryModel query, ContratoDTO data)
            : base(ctx, new Dictionary<ContratoQueryModel, ContratoDTO> { { query, data } }) { }
    }
    
    public partial class UpdateContratoCommand : BaseRequestableCommand<ContratoQueryModel, ContratoDTO>
    {
        public bool CreateIfNotExists { get; set; } = true;
        public UpdateContratoCommand(ILogRequestContext ctx, ContratoQueryModel query, ContratoDTO data, bool createIfNotExists = true)
            : base(ctx, query, data) { this.CreateIfNotExists = createIfNotExists; }
    }
    public partial class ActiveContratoCommand : ContratoSearchableCommand
    {
        public ActiveContratoCommand(ILogRequestContext ctx, ContratoQueryModel query)
            : base(ctx, query) { }
    }
    public partial class DeactiveContratoCommand : ContratoSearchableCommand
    {
        public DeactiveContratoCommand(ILogRequestContext ctx, ContratoQueryModel query)
            : base(ctx, query) { }
    }
    public class ContratoSearchableCommand : BaseSearchableCommand<ContratoQueryModel> {
        public ContratoSearchableCommand(ILogRequestContext ctx, ContratoQueryModel query)
            : base(ctx, query) { }
    }
