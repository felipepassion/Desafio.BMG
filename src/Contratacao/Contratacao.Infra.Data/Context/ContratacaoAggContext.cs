using Bmg.Desafio.Contratacao.Infra.Data.Aggregates.ContratacaoAgg.Mappings;
using Bmg.Desafio.Contratacao.Infra.Data.Aggregates.UsersAgg.Mappings;
using Bmg.Desafio.Core.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Bmg.Desafio.Contratacao.Infra.Data.Context
{
	public partial class ContratacaoAggContext : BaseContext
	{
		public DbSet<Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Entities.Contrato> Contrato { get; set; }
		public DbSet<Bmg.Desafio.Contratacao.Domain.Aggregates.UsersAgg.Entities.User> User { get; set; }

		public ContratacaoAggContext (MediatR.IMediator mediator, DbContextOptions<ContratacaoAggContext> options, IServiceProvider scope)
            : base(mediator, options, scope)
        {
        }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new ContratoMapping());
			builder.ApplyConfiguration(new UserMapping());
		
			ApplyAdditionalMappings(builder);
			base.OnModelCreating(builder);
		}
		partial void ApplyAdditionalMappings(ModelBuilder modelBuilder);
	}
}
