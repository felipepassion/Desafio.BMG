namespace Bmg.Desafio.Contratacao.Infra.Data.Aggregates.ContratacaoAgg.Repositories;

using Core.Infra.Data.Repositories;
using Context;
using Domain.Aggregates.ContratacaoAgg.Entities;
using Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Repositories;

	public partial class ContratoRepository : Repository<Contrato>, IContratoRepository { public ContratoRepository(ContratacaoAggContext ctx) : base(ctx) { } }

