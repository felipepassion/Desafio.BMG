using Bmg.Desafio.Core.Infra.Data.Contexts;
using Bmg.Desafio.Proposta.Infra.Data.Aggregates.PropostaAgg.Mappings;
using Bmg.Desafio.Proposta.Infra.Data.Aggregates.UsersAgg.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Bmg.Desafio.Proposta.Infra.Data.Context
{
	public partial class PropostaAggContext : BaseContext
	{
		public DbSet<Bmg.Desafio.Proposta.Domain.Aggregates.PropostaAgg.Entities.Proposta> Proposta { get; set; }
		public DbSet<Bmg.Desafio.Proposta.Domain.Aggregates.UsersAgg.Entities.User> User { get; set; }

		public PropostaAggContext (MediatR.IMediator mediator, DbContextOptions<PropostaAggContext> options, IServiceProvider scope)
            : base(mediator, options, scope)
        {
        }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new PropostaMapping());
			builder.ApplyConfiguration(new UserMapping());
		
			ApplyAdditionalMappings(builder);
			base.OnModelCreating(builder);
		}
		partial void ApplyAdditionalMappings(ModelBuilder modelBuilder);
	}
}
