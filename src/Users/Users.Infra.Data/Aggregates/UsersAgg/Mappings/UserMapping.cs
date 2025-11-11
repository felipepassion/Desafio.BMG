namespace Bmg.Desafio.Users.Infra.Data.Aggregates.UsersAgg.Mappings;

using Domain.Aggregates.UsersAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class UserMapping : IEntityTypeConfiguration<Bmg.Desafio.Users.Domain.Aggregates.UsersAgg.Entities.User>
{
    public void Configure(EntityTypeBuilder<Bmg.Desafio.Users.Domain.Aggregates.UsersAgg.Entities.User> builder)
    {
    }
}
