using Bmg.Desafio.Contratacao.Domain.Aggregates.UsersAgg.Entities;
using Bmg.Desafio.Contratacao.Enumerations;
using Bmg.Desafio.Core.Domain.Aggregates.CommonAgg.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Entities
{
    /// <summary>
    /// Entidade de Contrato (versão simplificada) criada a partir de uma Proposta aprovada.
    /// Só mantém propriedades necessárias às queries/specifications geradas.
    /// </summary>
    public class Contrato : Entity
    {
        /// <summary>
        /// Id da proposta aprovada usada como origem.
        /// </summary>
        [Required]
        public int PropostaId { get; set; }

        /// <summary>
        /// Id da proposta aprovada usada como origem.
        /// </summary>
        [NotMapped]
        public string PropostaExternalId { get; set; }

        /// <summary>
        /// Número legível do contrato.
        /// </summary>
        [Required, StringLength(40)]
        public string NumeroContrato { get; private set; }

        /// <summary>
        /// Data em que a contratação foi efetivada.
        /// </summary>
        [Required]
        public DateTime DataContratacao { get; private set; }

        /// <summary>
        /// Início da vigência (mantido porque Specifications usam).
        /// </summary>
        [Required]
        public DateTime InicioVigencia { get; private set; }

        /// <summary>
        /// Fim da vigência (mantido porque Specifications usam).
        /// </summary>
        [Required]
        public DateTime FimVigencia { get; private set; }

        /// <summary>
        /// Status atual do contrato.
        /// </summary>
        [Required]
        public ContratoStatus Status { get; private set; } = ContratoStatus.Ativo;

        /// <summary>
        /// Motivo de cancelamento (se Status = Cancelado).
        /// </summary>
        [StringLength(500)]
        public string? MotivoCancelamento { get; private set; }

        /// <summary>
        /// Data de cancelamento (se cancelado).
        /// </summary>
        public DateTime? DataCancelamento { get; private set; }

        /// <summary>
        /// Construtor ORM.
        /// </summary>
        public Contrato() { }

        /// <summary>
        /// Cria um novo contrato ativo.
        /// </summary>
        public Contrato(int propostaId, int userId, string numeroContrato, DateTime inicioVigencia, DateTime fimVigencia, decimal valorCobertura = 0)
        {
            if (fimVigencia <= inicioVigencia) throw new InvalidOperationException("Fim da vigência deve ser maior que início.");
            PropostaId = propostaId;
            UserId = userId;
            NumeroContrato = numeroContrato;
            InicioVigencia = inicioVigencia.Date;
            FimVigencia = fimVigencia.Date;
            DataContratacao = DateTime.UtcNow;
            Status = ContratoStatus.Ativo;
        }

        /// <summary>
        /// Cancela o contrato (somente se Ativo).
        /// </summary>
        public void Cancelar(string motivo)
        {
            if (Status != ContratoStatus.Ativo) throw new InvalidOperationException("Somente contratos Ativos podem ser cancelados.");
            if (string.IsNullOrWhiteSpace(motivo)) throw new InvalidOperationException("Motivo de cancelamento é obrigatório.");
            Status = ContratoStatus.Cancelado;
            MotivoCancelamento = motivo.Trim();
            DataCancelamento = DateTime.UtcNow;
        }

        /// <summary>
        /// Encerra o contrato (fluxo simples de término natural).
        /// </summary>
        public void Encerrar()
        {
            if (Status != ContratoStatus.Ativo) throw new InvalidOperationException("Somente contratos Ativos podem ser encerrados.");
            Status = ContratoStatus.Encerrado;
        }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
