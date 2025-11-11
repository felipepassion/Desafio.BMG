using System.ComponentModel.DataAnnotations;

namespace Bmg.Desafio.Proposta.Application.DTO.Aggregates.PropostaAgg.Requests;

using Core.Application.DTO.Aggregates.CommonAgg.Models;

public partial class PropostaDTO : EntityDTO
	{
	    public  int? UserId { get; set; }
	    [Required] public  Bmg.Desafio.Proposta.Enumerations.PropostaStatus Status { get; set; }
		///<summary>Valor de cobertura estimada (mantido para atender Specifications/Queries).</summary>
	    public  decimal? ValorCobertura { get; set; }
	    public  string? MotivoRejeicao { get; set; }
	    public System.DateTime? DataAprovacao { get; set; } 
	    public System.DateTime? DataRejeicao { get; set; } 
	    public  bool? Contratada { get; set; }
	    public Bmg.Desafio.Proposta.Application.DTO.Aggregates.UsersAgg.Requests.UserDTO? User { get; set; } 
	}
