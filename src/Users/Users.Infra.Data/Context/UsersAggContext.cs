using Bmg.Desafio.Core.Infra.Data.Contexts;
using Bmg.Desafio.Users.Infra.Data.Aggregates.UsersAgg.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Bmg.Desafio.Users.Infra.Data.Context
{
	public partial class UsersAggContext : BaseContext
	{
		public DbSet<Bmg.Desafio.Users.Domain.Aggregates.UsersAgg.Entities.User> User { get; set; }

		public UsersAggContext (MediatR.IMediator mediator, DbContextOptions<UsersAggContext> options, IServiceProvider scope)
            : base(mediator, options, scope)
        {
        }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new UserMapping());
		
			ApplyAdditionalMappings(builder);
			base.OnModelCreating(builder);
		}
		partial void ApplyAdditionalMappings(ModelBuilder modelBuilder);
	}
}
