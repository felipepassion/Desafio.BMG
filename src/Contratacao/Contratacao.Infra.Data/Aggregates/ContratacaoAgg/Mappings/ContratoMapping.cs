namespace Bmg.Desafio.Contratacao.Infra.Data.Aggregates.ContratacaoAgg.Mappings;

using Domain.Aggregates.ContratacaoAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class ContratoMapping : IEntityTypeConfiguration<Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Entities.Contrato>
{
    public void Configure(EntityTypeBuilder<Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Entities.Contrato> builder)
    {
    }
}
