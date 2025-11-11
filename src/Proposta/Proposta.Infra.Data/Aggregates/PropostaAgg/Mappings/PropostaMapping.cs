namespace Bmg.Desafio.Proposta.Infra.Data.Aggregates.PropostaAgg.Mappings;

using Domain.Aggregates.PropostaAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class PropostaMapping : IEntityTypeConfiguration<Bmg.Desafio.Proposta.Domain.Aggregates.PropostaAgg.Entities.Proposta>
{
    public void Configure(EntityTypeBuilder<Bmg.Desafio.Proposta.Domain.Aggregates.PropostaAgg.Entities.Proposta> builder)
    {
    }
}
