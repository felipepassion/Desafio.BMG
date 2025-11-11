using System.Collections;
using System.Text.Json.Serialization;

namespace Bmg.Desafio.Core.Application.DTO.Aggregates.CommonAgg.Models;

public interface IEntityDTO
{
    public string? ExternalId { get; set; }
    public DateTime? CriadoEm { get; set; }
}

public class EntityDTO : IEntityDTO, IEqualityComparer
{
    public int? Id { get; set; }

    public bool IsCreated { get; set; }
    public string? ExternalId { get; set; } = Guid.NewGuid().ToString();

    public DateTime? CriadoEm { get; set; }

    public DateTime? AtualizadoEm { get; set; }

    public new bool Equals(object? x, object? y) => (x as IEntityDTO)?.ExternalId == (y as IEntityDTO)?.ExternalId;

    public int GetHashCode(object obj) => base.GetHashCode();
}
