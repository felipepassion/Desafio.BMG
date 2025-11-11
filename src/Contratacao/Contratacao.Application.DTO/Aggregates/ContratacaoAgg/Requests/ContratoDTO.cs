using System.ComponentModel.DataAnnotations;

namespace Bmg.Desafio.Contratacao.Application.DTO.Aggregates.ContratacaoAgg.Requests;

using Core.Application.DTO.Aggregates.CommonAgg.Models;

public partial class ContratoDTO : EntityDTO
{
    ///<summary>Id da proposta aprovada usada como origem.</summary>
    [Required] public int PropostaId { get; set; }
    ///<summary>Id da proposta aprovada usada como origem.</summary>
    public string? PropostaExternalId { get; set; }
    ///<summary>Número legível do contrato.</summary>
    [Required] public string NumeroContrato { get; set; }
    ///<summary>Data em que a contratação foi efetivada.</summary>
    [Required] public System.DateTime DataContratacao { get; set; }
    ///<summary>Início da vigência (mantido porque Specifications usam).</summary>
    [Required] public System.DateTime InicioVigencia { get; set; }
    ///<summary>Fim da vigência (mantido porque Specifications usam).</summary>
    [Required] public System.DateTime FimVigencia { get; set; }
    ///<summary>Status atual do contrato.</summary>
    [Required] public Bmg.Desafio.Contratacao.Enumerations.ContratoStatus Status { get; set; }
    ///<summary>Motivo de cancelamento (se Status = Cancelado).</summary>
    public string? MotivoCancelamento { get; set; }
    ///<summary>Data de cancelamento (se cancelado).</summary>
    public System.DateTime? DataCancelamento { get; set; }
    public int? UserId { get; set; }
    public Bmg.Desafio.Contratacao.Application.DTO.Aggregates.UsersAgg.Requests.UserDTO? User { get; set; }
}
