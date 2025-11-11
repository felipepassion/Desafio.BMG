namespace Bmg.Desafio.Contratacao.Infra.Data.Aggregates.UsersAgg.Mappings;

using Domain.Aggregates.ContratacaoAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class UserMapping : IEntityTypeConfiguration<Bmg.Desafio.Contratacao.Domain.Aggregates.UsersAgg.Entities.User>
{
    public void Configure(EntityTypeBuilder<Bmg.Desafio.Contratacao.Domain.Aggregates.UsersAgg.Entities.User> builder)
    {
        builder.Metadata.SetIsTableExcludedFromMigrations(true);
    }
}
