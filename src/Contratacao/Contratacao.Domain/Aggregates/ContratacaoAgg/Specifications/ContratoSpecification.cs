namespace Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Specifications;
using Entities;
using Microsoft.EntityFrameworkCore;
using Core.Domain.Seedwork.Specification;
public partial class ContratoSpecifications {
				public static Specification<Contrato> PropostaIdContains(params int[] values) {
            return new DirectSpecification<Contrato>(p => values.Contains(p.PropostaId));
        }
		public static Specification<Contrato> PropostaIdNotContains(params int[] values) {
            return new DirectSpecification<Contrato>(p => !values.Contains(p.PropostaId));
        }
		public static Specification<Contrato> PropostaIdEqual(params int[] values) {
			return new DirectSpecification<Contrato>(p => values.Contains(p.PropostaId));
        }
        public static Specification<Contrato> PropostaIdGreaterThanOrEqual(int value) {
            return new DirectSpecification<Contrato>(p => p.PropostaId >= value);
        }
        public static Specification<Contrato> PropostaIdLessThanOrEqual(int value) {
            return new DirectSpecification<Contrato>(p => p.PropostaId <= value);
        }
        public static Specification<Contrato> PropostaIdNotEqual(int value) {
            return new DirectSpecification<Contrato>(p => p.PropostaId != value);
        }
        public static Specification<Contrato> PropostaIdGreaterThan(int value) {
            return new DirectSpecification<Contrato>(p => p.PropostaId > value);
        }
        public static Specification<Contrato> PropostaIdLessThan(int value) {
            return new DirectSpecification<Contrato>(p => p.PropostaId < value);
        }
		
					public static Specification<Contrato> NumeroContratoContains(string value) {
			return new DirectSpecification<Contrato>(p => EF.Functions.Like(p.NumeroContrato.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<Contrato> NumeroContratoNotContains(string value) {
			return new DirectSpecification<Contrato>(p => !EF.Functions.Like(p.NumeroContrato.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<Contrato> NumeroContratoStartsWith(string value) {
			return new DirectSpecification<Contrato>(p => EF.Functions.Like(p.NumeroContrato.ToLower(), $"{value.ToLower()}%"));
		}
	
		public static Specification<Contrato> NumeroContratoEqual(string value) {
			return new DirectSpecification<Contrato>(p => value.ToLower() == (p.NumeroContrato.ToLower()));
		}
		public static Specification<Contrato> NumeroContratoNotEqual(string value) {
			return new DirectSpecification<Contrato>(p => p.NumeroContrato != value);
		}
		public static Specification<Contrato> NumeroContratoIsNull() {
            return new DirectSpecification<Contrato>(p => p.NumeroContrato == null);
        }
		public static Specification<Contrato> NumeroContratoIsNotNull() {
            return new DirectSpecification<Contrato>(p => p.NumeroContrato != null);
        }
		
					public static Specification<Contrato> DataContratacaoContains(params System.DateTime[] values) {
            return new DirectSpecification<Contrato>(p => values.Contains(p.DataContratacao));
        }
		public static Specification<Contrato> DataContratacaoNotContains(params System.DateTime[] values) {
            return new DirectSpecification<Contrato>(p => !values.Contains(p.DataContratacao));
        }
		public static Specification<Contrato> DataContratacaoEqual(params System.DateTime[] values) {
			return new DirectSpecification<Contrato>(p => values.Contains(p.DataContratacao));
        }
        public static Specification<Contrato> DataContratacaoGreaterThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.DataContratacao >= value);
        }
        public static Specification<Contrato> DataContratacaoLessThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.DataContratacao <= value);
        }
        public static Specification<Contrato> DataContratacaoNotEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.DataContratacao != value);
        }
        public static Specification<Contrato> DataContratacaoGreaterThan(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.DataContratacao > value);
        }
        public static Specification<Contrato> DataContratacaoLessThan(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.DataContratacao < value);
        }
		
					public static Specification<Contrato> InicioVigenciaContains(params System.DateTime[] values) {
            return new DirectSpecification<Contrato>(p => values.Contains(p.InicioVigencia));
        }
		public static Specification<Contrato> InicioVigenciaNotContains(params System.DateTime[] values) {
            return new DirectSpecification<Contrato>(p => !values.Contains(p.InicioVigencia));
        }
		public static Specification<Contrato> InicioVigenciaEqual(params System.DateTime[] values) {
			return new DirectSpecification<Contrato>(p => values.Contains(p.InicioVigencia));
        }
        public static Specification<Contrato> InicioVigenciaGreaterThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.InicioVigencia >= value);
        }
        public static Specification<Contrato> InicioVigenciaLessThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.InicioVigencia <= value);
        }
        public static Specification<Contrato> InicioVigenciaNotEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.InicioVigencia != value);
        }
        public static Specification<Contrato> InicioVigenciaGreaterThan(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.InicioVigencia > value);
        }
        public static Specification<Contrato> InicioVigenciaLessThan(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.InicioVigencia < value);
        }
		
					public static Specification<Contrato> FimVigenciaContains(params System.DateTime[] values) {
            return new DirectSpecification<Contrato>(p => values.Contains(p.FimVigencia));
        }
		public static Specification<Contrato> FimVigenciaNotContains(params System.DateTime[] values) {
            return new DirectSpecification<Contrato>(p => !values.Contains(p.FimVigencia));
        }
		public static Specification<Contrato> FimVigenciaEqual(params System.DateTime[] values) {
			return new DirectSpecification<Contrato>(p => values.Contains(p.FimVigencia));
        }
        public static Specification<Contrato> FimVigenciaGreaterThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.FimVigencia >= value);
        }
        public static Specification<Contrato> FimVigenciaLessThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.FimVigencia <= value);
        }
        public static Specification<Contrato> FimVigenciaNotEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.FimVigencia != value);
        }
        public static Specification<Contrato> FimVigenciaGreaterThan(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.FimVigencia > value);
        }
        public static Specification<Contrato> FimVigenciaLessThan(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.FimVigencia < value);
        }
		
					public static Specification<Contrato> StatusEqual(params Bmg.Desafio.Contratacao.Enumerations.ContratoStatus[] values) {
			return new DirectSpecification<Contrato>(p => values.Contains(p.Status));
		}
		public static Specification<Contrato> StatusNotEqual(Bmg.Desafio.Contratacao.Enumerations.ContratoStatus value) {
			return new DirectSpecification<Contrato>(p => p.Status != value);
		}
	
					public static Specification<Contrato> MotivoCancelamentoContains(string value) {
			return new DirectSpecification<Contrato>(p => EF.Functions.Like(p.MotivoCancelamento.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<Contrato> MotivoCancelamentoNotContains(string value) {
			return new DirectSpecification<Contrato>(p => !EF.Functions.Like(p.MotivoCancelamento.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<Contrato> MotivoCancelamentoStartsWith(string value) {
			return new DirectSpecification<Contrato>(p => EF.Functions.Like(p.MotivoCancelamento.ToLower(), $"{value.ToLower()}%"));
		}
	
		public static Specification<Contrato> MotivoCancelamentoEqual(string value) {
			return new DirectSpecification<Contrato>(p => value.ToLower() == (p.MotivoCancelamento.ToLower()));
		}
		public static Specification<Contrato> MotivoCancelamentoNotEqual(string value) {
			return new DirectSpecification<Contrato>(p => p.MotivoCancelamento != value);
		}
		public static Specification<Contrato> MotivoCancelamentoIsNull() {
            return new DirectSpecification<Contrato>(p => p.MotivoCancelamento == null);
        }
		public static Specification<Contrato> MotivoCancelamentoIsNotNull() {
            return new DirectSpecification<Contrato>(p => p.MotivoCancelamento != null);
        }
		
					public static Specification<Contrato> DataCancelamentoContains(params System.DateTime[] values) {
            return new DirectSpecification<Contrato>(p => values.Contains(p.DataCancelamento.Value));
        }
		public static Specification<Contrato> DataCancelamentoNotContains(params System.DateTime[] values) {
            return new DirectSpecification<Contrato>(p => !values.Contains(p.DataCancelamento.Value));
        }
		public static Specification<Contrato> DataCancelamentoEqual(params System.DateTime[] values) {
			return new DirectSpecification<Contrato>(p => values.Contains(p.DataCancelamento.Value));
        }
        public static Specification<Contrato> DataCancelamentoGreaterThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.DataCancelamento >= value);
        }
        public static Specification<Contrato> DataCancelamentoLessThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.DataCancelamento <= value);
        }
        public static Specification<Contrato> DataCancelamentoNotEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.DataCancelamento != value);
        }
        public static Specification<Contrato> DataCancelamentoGreaterThan(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.DataCancelamento > value);
        }
        public static Specification<Contrato> DataCancelamentoLessThan(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.DataCancelamento < value);
        }
		
					public static Specification<Contrato> UserIdContains(params int[] values) {
            return new DirectSpecification<Contrato>(p => values.Contains(p.UserId));
        }
		public static Specification<Contrato> UserIdNotContains(params int[] values) {
            return new DirectSpecification<Contrato>(p => !values.Contains(p.UserId));
        }
		public static Specification<Contrato> UserIdEqual(params int[] values) {
			return new DirectSpecification<Contrato>(p => values.Contains(p.UserId));
        }
        public static Specification<Contrato> UserIdGreaterThanOrEqual(int value) {
            return new DirectSpecification<Contrato>(p => p.UserId >= value);
        }
        public static Specification<Contrato> UserIdLessThanOrEqual(int value) {
            return new DirectSpecification<Contrato>(p => p.UserId <= value);
        }
        public static Specification<Contrato> UserIdNotEqual(int value) {
            return new DirectSpecification<Contrato>(p => p.UserId != value);
        }
        public static Specification<Contrato> UserIdGreaterThan(int value) {
            return new DirectSpecification<Contrato>(p => p.UserId > value);
        }
        public static Specification<Contrato> UserIdLessThan(int value) {
            return new DirectSpecification<Contrato>(p => p.UserId < value);
        }
		
				
					public static Specification<Contrato> ExternalIdContains(string value) {
			return new DirectSpecification<Contrato>(p => EF.Functions.Like(p.ExternalId.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<Contrato> ExternalIdNotContains(string value) {
			return new DirectSpecification<Contrato>(p => !EF.Functions.Like(p.ExternalId.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<Contrato> ExternalIdStartsWith(string value) {
			return new DirectSpecification<Contrato>(p => EF.Functions.Like(p.ExternalId.ToLower(), $"{value.ToLower()}%"));
		}
	
		public static Specification<Contrato> ExternalIdEqual(string value) {
			return new DirectSpecification<Contrato>(p => value.ToLower() == (p.ExternalId.ToLower()));
		}
		public static Specification<Contrato> ExternalIdNotEqual(string value) {
			return new DirectSpecification<Contrato>(p => p.ExternalId != value);
		}
		public static Specification<Contrato> ExternalIdIsNull() {
            return new DirectSpecification<Contrato>(p => p.ExternalId == null);
        }
		public static Specification<Contrato> ExternalIdIsNotNull() {
            return new DirectSpecification<Contrato>(p => p.ExternalId != null);
        }
		
					public static Specification<Contrato> CreatedAtContains(params System.DateTime[] values) {
            return new DirectSpecification<Contrato>(p => values.Contains(p.CreatedAt.Value));
        }
		public static Specification<Contrato> CreatedAtNotContains(params System.DateTime[] values) {
            return new DirectSpecification<Contrato>(p => !values.Contains(p.CreatedAt.Value));
        }
		public static Specification<Contrato> CreatedAtEqual(params System.DateTime[] values) {
			return new DirectSpecification<Contrato>(p => values.Contains(p.CreatedAt.Value));
        }
        public static Specification<Contrato> CreatedAtGreaterThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.CreatedAt >= value);
        }
        public static Specification<Contrato> CreatedAtLessThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.CreatedAt <= value);
        }
        public static Specification<Contrato> CreatedAtNotEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.CreatedAt != value);
        }
        public static Specification<Contrato> CreatedAtGreaterThan(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.CreatedAt > value);
        }
        public static Specification<Contrato> CreatedAtLessThan(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.CreatedAt < value);
        }
		
					public static Specification<Contrato> UpdatedAtContains(params System.DateTime[] values) {
            return new DirectSpecification<Contrato>(p => values.Contains(p.UpdatedAt.Value));
        }
		public static Specification<Contrato> UpdatedAtNotContains(params System.DateTime[] values) {
            return new DirectSpecification<Contrato>(p => !values.Contains(p.UpdatedAt.Value));
        }
		public static Specification<Contrato> UpdatedAtEqual(params System.DateTime[] values) {
			return new DirectSpecification<Contrato>(p => values.Contains(p.UpdatedAt.Value));
        }
        public static Specification<Contrato> UpdatedAtGreaterThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.UpdatedAt >= value);
        }
        public static Specification<Contrato> UpdatedAtLessThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.UpdatedAt <= value);
        }
        public static Specification<Contrato> UpdatedAtNotEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.UpdatedAt != value);
        }
        public static Specification<Contrato> UpdatedAtGreaterThan(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.UpdatedAt > value);
        }
        public static Specification<Contrato> UpdatedAtLessThan(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.UpdatedAt < value);
        }
		
					public static Specification<Contrato> DeletedAtContains(params System.DateTime[] values) {
            return new DirectSpecification<Contrato>(p => values.Contains(p.DeletedAt.Value));
        }
		public static Specification<Contrato> DeletedAtNotContains(params System.DateTime[] values) {
            return new DirectSpecification<Contrato>(p => !values.Contains(p.DeletedAt.Value));
        }
		public static Specification<Contrato> DeletedAtEqual(params System.DateTime[] values) {
			return new DirectSpecification<Contrato>(p => values.Contains(p.DeletedAt.Value));
        }
        public static Specification<Contrato> DeletedAtGreaterThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.DeletedAt >= value);
        }
        public static Specification<Contrato> DeletedAtLessThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.DeletedAt <= value);
        }
        public static Specification<Contrato> DeletedAtNotEqual(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.DeletedAt != value);
        }
        public static Specification<Contrato> DeletedAtGreaterThan(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.DeletedAt > value);
        }
        public static Specification<Contrato> DeletedAtLessThan(System.DateTime value) {
            return new DirectSpecification<Contrato>(p => p.DeletedAt < value);
        }
		
					public static Specification<Contrato> IdContains(params int[] values) {
            return new DirectSpecification<Contrato>(p => values.Contains(p.Id));
        }
		public static Specification<Contrato> IdNotContains(params int[] values) {
            return new DirectSpecification<Contrato>(p => !values.Contains(p.Id));
        }
		public static Specification<Contrato> IdEqual(params int[] values) {
			return new DirectSpecification<Contrato>(p => values.Contains(p.Id));
        }
        public static Specification<Contrato> IdGreaterThanOrEqual(int value) {
            return new DirectSpecification<Contrato>(p => p.Id >= value);
        }
        public static Specification<Contrato> IdLessThanOrEqual(int value) {
            return new DirectSpecification<Contrato>(p => p.Id <= value);
        }
        public static Specification<Contrato> IdNotEqual(int value) {
            return new DirectSpecification<Contrato>(p => p.Id != value);
        }
        public static Specification<Contrato> IdGreaterThan(int value) {
            return new DirectSpecification<Contrato>(p => p.Id > value);
        }
        public static Specification<Contrato> IdLessThan(int value) {
            return new DirectSpecification<Contrato>(p => p.Id < value);
        }
		
					public static Specification<Contrato> DeletadoEqual(bool value) {
			return new DirectSpecification<Contrato>(p => p.Deletado == value);
		}
		
	   }
