namespace Bmg.Desafio.Proposta.Infra.Data.Aggregates.PropostaAgg.Repositories;

using Core.Infra.Data.Repositories;
using Context;
using Domain.Aggregates.PropostaAgg.Entities;
using Bmg.Desafio.Proposta.Domain.Aggregates.PropostaAgg.Repositories;

	public partial class PropostaRepository : Repository<Proposta>, IPropostaRepository { public PropostaRepository(PropostaAggContext ctx) : base(ctx) { } }

