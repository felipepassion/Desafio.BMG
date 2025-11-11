using Bmg.Desafio.Core.Domain.Aggregates.CommonAgg.Entities;
using Bmg.Desafio.Proposta.Domain.Aggregates.UsersAgg.Entities;
using Bmg.Desafio.Proposta.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmg.Desafio.Proposta.Domain.Aggregates.PropostaAgg.Entities
{
    public class Proposta : Entity
    {
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public PropostaStatus Status { get; private set; } = PropostaStatus.EmAnalise;

        /// <summary>
        /// Valor de cobertura estimada (mantido para atender Specifications/Queries).
        /// </summary>
        [Range(0, double.MaxValue)]
        public decimal ValorCobertura { get; private set; }

        [StringLength(500)]
        public string? MotivoRejeicao { get; private set; }

        public DateTime? DataAprovacao { get; private set; }

        public DateTime? DataRejeicao { get; private set; }

        public bool Contratada { get; private set; }

        public User User { get; set; }

        public Proposta() { }

        public Proposta(int userId, decimal valorPremio = 0, decimal valorCobertura = 0)
        {
            UserId = userId;
            ValorCobertura = valorCobertura;
            Status = PropostaStatus.EmAnalise;
        }

        /// <summary>
        /// Ajusta valores econômicos somente enquanto Em Análise.
        /// </summary>
        public void DefinirValores(decimal premio, decimal cobertura)
        {
            if (Status != PropostaStatus.EmAnalise) throw new InvalidOperationException("Só é permitido ajustar valores enquanto a proposta está Em Análise.");
            if (premio < 0 || cobertura < 0) throw new InvalidOperationException("Valores não podem ser negativos.");
            ValorCobertura = cobertura;
        }

        public void Aprovar()
        {
            if (Status != PropostaStatus.EmAnalise) throw new InvalidOperationException("Somente propostas Em Análise podem ser aprovadas.");
            Status = PropostaStatus.Aprovada;
            DataAprovacao = DateTime.UtcNow;
            DataRejeicao = null;
            MotivoRejeicao = null;
        }

        public void Rejeitar(string motivo)
        {
            if (Status != PropostaStatus.EmAnalise) throw new InvalidOperationException("Somente propostas Em Análise podem ser rejeitadas.");
            if (string.IsNullOrWhiteSpace(motivo)) throw new InvalidOperationException("Motivo de rejeição é obrigatório.");
            Status = PropostaStatus.Rejeitada;
            DataRejeicao = DateTime.UtcNow;
            MotivoRejeicao = motivo.Trim();
            DataAprovacao = null;
        }

        public void MarcarComoContratada()
        {
            if (Status != PropostaStatus.Aprovada) throw new InvalidOperationException("A proposta precisa estar Aprovada para ser contratada.");
            if (Contratada) throw new InvalidOperationException("Proposta já contratada.");
            Contratada = true;
        }

        public bool PodeSerContratada() => Status == PropostaStatus.Aprovada && !Contratada;
    }
}
