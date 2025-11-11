namespace Bmg.Desafio.Proposta.Infra.Data.Aggregates.UsersAgg.Mappings;

using Domain.Aggregates.PropostaAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class UserMapping : IEntityTypeConfiguration<Bmg.Desafio.Proposta.Domain.Aggregates.UsersAgg.Entities.User>
{
    public void Configure(EntityTypeBuilder<Bmg.Desafio.Proposta.Domain.Aggregates.UsersAgg.Entities.User> builder)
    {
        builder.Metadata.SetIsTableExcludedFromMigrations(true);
    }
}
