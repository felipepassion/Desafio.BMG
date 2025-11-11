namespace Bmg.Desafio.Proposta.Domain.Aggregates.PropostaAgg.Specifications;
using Entities;
using Microsoft.EntityFrameworkCore;
using Core.Domain.Seedwork.Specification;
public partial class PropostaSpecifications {
				public static Specification<Proposta> UserIdContains(params int[] values) {
            return new DirectSpecification<Proposta>(p => values.Contains(p.UserId));
        }
		public static Specification<Proposta> UserIdNotContains(params int[] values) {
            return new DirectSpecification<Proposta>(p => !values.Contains(p.UserId));
        }
		public static Specification<Proposta> UserIdEqual(params int[] values) {
			return new DirectSpecification<Proposta>(p => values.Contains(p.UserId));
        }
        public static Specification<Proposta> UserIdGreaterThanOrEqual(int value) {
            return new DirectSpecification<Proposta>(p => p.UserId >= value);
        }
        public static Specification<Proposta> UserIdLessThanOrEqual(int value) {
            return new DirectSpecification<Proposta>(p => p.UserId <= value);
        }
        public static Specification<Proposta> UserIdNotEqual(int value) {
            return new DirectSpecification<Proposta>(p => p.UserId != value);
        }
        public static Specification<Proposta> UserIdGreaterThan(int value) {
            return new DirectSpecification<Proposta>(p => p.UserId > value);
        }
        public static Specification<Proposta> UserIdLessThan(int value) {
            return new DirectSpecification<Proposta>(p => p.UserId < value);
        }
		
					public static Specification<Proposta> StatusEqual(params Bmg.Desafio.Proposta.Enumerations.PropostaStatus[] values) {
			return new DirectSpecification<Proposta>(p => values.Contains(p.Status));
		}
		public static Specification<Proposta> StatusNotEqual(Bmg.Desafio.Proposta.Enumerations.PropostaStatus value) {
			return new DirectSpecification<Proposta>(p => p.Status != value);
		}
	
					public static Specification<Proposta> ValorCoberturaContains(params decimal[] values) {
            return new DirectSpecification<Proposta>(p => values.Contains(p.ValorCobertura));
        }
		public static Specification<Proposta> ValorCoberturaNotContains(params decimal[] values) {
            return new DirectSpecification<Proposta>(p => !values.Contains(p.ValorCobertura));
        }
		public static Specification<Proposta> ValorCoberturaEqual(params decimal[] values) {
			return new DirectSpecification<Proposta>(p => values.Contains(p.ValorCobertura));
        }
        public static Specification<Proposta> ValorCoberturaGreaterThanOrEqual(decimal value) {
            return new DirectSpecification<Proposta>(p => p.ValorCobertura >= value);
        }
        public static Specification<Proposta> ValorCoberturaLessThanOrEqual(decimal value) {
            return new DirectSpecification<Proposta>(p => p.ValorCobertura <= value);
        }
        public static Specification<Proposta> ValorCoberturaNotEqual(decimal value) {
            return new DirectSpecification<Proposta>(p => p.ValorCobertura != value);
        }
        public static Specification<Proposta> ValorCoberturaGreaterThan(decimal value) {
            return new DirectSpecification<Proposta>(p => p.ValorCobertura > value);
        }
        public static Specification<Proposta> ValorCoberturaLessThan(decimal value) {
            return new DirectSpecification<Proposta>(p => p.ValorCobertura < value);
        }
		
					public static Specification<Proposta> MotivoRejeicaoContains(string value) {
			return new DirectSpecification<Proposta>(p => EF.Functions.Like(p.MotivoRejeicao.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<Proposta> MotivoRejeicaoNotContains(string value) {
			return new DirectSpecification<Proposta>(p => !EF.Functions.Like(p.MotivoRejeicao.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<Proposta> MotivoRejeicaoStartsWith(string value) {
			return new DirectSpecification<Proposta>(p => EF.Functions.Like(p.MotivoRejeicao.ToLower(), $"{value.ToLower()}%"));
		}
	
		public static Specification<Proposta> MotivoRejeicaoEqual(string value) {
			return new DirectSpecification<Proposta>(p => value.ToLower() == (p.MotivoRejeicao.ToLower()));
		}
		public static Specification<Proposta> MotivoRejeicaoNotEqual(string value) {
			return new DirectSpecification<Proposta>(p => p.MotivoRejeicao != value);
		}
		public static Specification<Proposta> MotivoRejeicaoIsNull() {
            return new DirectSpecification<Proposta>(p => p.MotivoRejeicao == null);
        }
		public static Specification<Proposta> MotivoRejeicaoIsNotNull() {
            return new DirectSpecification<Proposta>(p => p.MotivoRejeicao != null);
        }
		
					public static Specification<Proposta> DataAprovacaoContains(params System.DateTime[] values) {
            return new DirectSpecification<Proposta>(p => values.Contains(p.DataAprovacao.Value));
        }
		public static Specification<Proposta> DataAprovacaoNotContains(params System.DateTime[] values) {
            return new DirectSpecification<Proposta>(p => !values.Contains(p.DataAprovacao.Value));
        }
		public static Specification<Proposta> DataAprovacaoEqual(params System.DateTime[] values) {
			return new DirectSpecification<Proposta>(p => values.Contains(p.DataAprovacao.Value));
        }
        public static Specification<Proposta> DataAprovacaoGreaterThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.DataAprovacao >= value);
        }
        public static Specification<Proposta> DataAprovacaoLessThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.DataAprovacao <= value);
        }
        public static Specification<Proposta> DataAprovacaoNotEqual(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.DataAprovacao != value);
        }
        public static Specification<Proposta> DataAprovacaoGreaterThan(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.DataAprovacao > value);
        }
        public static Specification<Proposta> DataAprovacaoLessThan(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.DataAprovacao < value);
        }
		
					public static Specification<Proposta> DataRejeicaoContains(params System.DateTime[] values) {
            return new DirectSpecification<Proposta>(p => values.Contains(p.DataRejeicao.Value));
        }
		public static Specification<Proposta> DataRejeicaoNotContains(params System.DateTime[] values) {
            return new DirectSpecification<Proposta>(p => !values.Contains(p.DataRejeicao.Value));
        }
		public static Specification<Proposta> DataRejeicaoEqual(params System.DateTime[] values) {
			return new DirectSpecification<Proposta>(p => values.Contains(p.DataRejeicao.Value));
        }
        public static Specification<Proposta> DataRejeicaoGreaterThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.DataRejeicao >= value);
        }
        public static Specification<Proposta> DataRejeicaoLessThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.DataRejeicao <= value);
        }
        public static Specification<Proposta> DataRejeicaoNotEqual(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.DataRejeicao != value);
        }
        public static Specification<Proposta> DataRejeicaoGreaterThan(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.DataRejeicao > value);
        }
        public static Specification<Proposta> DataRejeicaoLessThan(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.DataRejeicao < value);
        }
		
					public static Specification<Proposta> ContratadaEqual(bool value) {
			return new DirectSpecification<Proposta>(p => p.Contratada == value);
		}
		
				
					public static Specification<Proposta> ExternalIdContains(string value) {
			return new DirectSpecification<Proposta>(p => EF.Functions.Like(p.ExternalId.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<Proposta> ExternalIdNotContains(string value) {
			return new DirectSpecification<Proposta>(p => !EF.Functions.Like(p.ExternalId.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<Proposta> ExternalIdStartsWith(string value) {
			return new DirectSpecification<Proposta>(p => EF.Functions.Like(p.ExternalId.ToLower(), $"{value.ToLower()}%"));
		}
	
		public static Specification<Proposta> ExternalIdEqual(string value) {
			return new DirectSpecification<Proposta>(p => value.ToLower() == (p.ExternalId.ToLower()));
		}
		public static Specification<Proposta> ExternalIdNotEqual(string value) {
			return new DirectSpecification<Proposta>(p => p.ExternalId != value);
		}
		public static Specification<Proposta> ExternalIdIsNull() {
            return new DirectSpecification<Proposta>(p => p.ExternalId == null);
        }
		public static Specification<Proposta> ExternalIdIsNotNull() {
            return new DirectSpecification<Proposta>(p => p.ExternalId != null);
        }
		
					public static Specification<Proposta> CreatedAtContains(params System.DateTime[] values) {
            return new DirectSpecification<Proposta>(p => values.Contains(p.CreatedAt.Value));
        }
		public static Specification<Proposta> CreatedAtNotContains(params System.DateTime[] values) {
            return new DirectSpecification<Proposta>(p => !values.Contains(p.CreatedAt.Value));
        }
		public static Specification<Proposta> CreatedAtEqual(params System.DateTime[] values) {
			return new DirectSpecification<Proposta>(p => values.Contains(p.CreatedAt.Value));
        }
        public static Specification<Proposta> CreatedAtGreaterThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.CreatedAt >= value);
        }
        public static Specification<Proposta> CreatedAtLessThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.CreatedAt <= value);
        }
        public static Specification<Proposta> CreatedAtNotEqual(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.CreatedAt != value);
        }
        public static Specification<Proposta> CreatedAtGreaterThan(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.CreatedAt > value);
        }
        public static Specification<Proposta> CreatedAtLessThan(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.CreatedAt < value);
        }
		
					public static Specification<Proposta> UpdatedAtContains(params System.DateTime[] values) {
            return new DirectSpecification<Proposta>(p => values.Contains(p.UpdatedAt.Value));
        }
		public static Specification<Proposta> UpdatedAtNotContains(params System.DateTime[] values) {
            return new DirectSpecification<Proposta>(p => !values.Contains(p.UpdatedAt.Value));
        }
		public static Specification<Proposta> UpdatedAtEqual(params System.DateTime[] values) {
			return new DirectSpecification<Proposta>(p => values.Contains(p.UpdatedAt.Value));
        }
        public static Specification<Proposta> UpdatedAtGreaterThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.UpdatedAt >= value);
        }
        public static Specification<Proposta> UpdatedAtLessThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.UpdatedAt <= value);
        }
        public static Specification<Proposta> UpdatedAtNotEqual(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.UpdatedAt != value);
        }
        public static Specification<Proposta> UpdatedAtGreaterThan(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.UpdatedAt > value);
        }
        public static Specification<Proposta> UpdatedAtLessThan(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.UpdatedAt < value);
        }
		
					public static Specification<Proposta> DeletedAtContains(params System.DateTime[] values) {
            return new DirectSpecification<Proposta>(p => values.Contains(p.DeletedAt.Value));
        }
		public static Specification<Proposta> DeletedAtNotContains(params System.DateTime[] values) {
            return new DirectSpecification<Proposta>(p => !values.Contains(p.DeletedAt.Value));
        }
		public static Specification<Proposta> DeletedAtEqual(params System.DateTime[] values) {
			return new DirectSpecification<Proposta>(p => values.Contains(p.DeletedAt.Value));
        }
        public static Specification<Proposta> DeletedAtGreaterThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.DeletedAt >= value);
        }
        public static Specification<Proposta> DeletedAtLessThanOrEqual(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.DeletedAt <= value);
        }
        public static Specification<Proposta> DeletedAtNotEqual(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.DeletedAt != value);
        }
        public static Specification<Proposta> DeletedAtGreaterThan(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.DeletedAt > value);
        }
        public static Specification<Proposta> DeletedAtLessThan(System.DateTime value) {
            return new DirectSpecification<Proposta>(p => p.DeletedAt < value);
        }
		
					public static Specification<Proposta> IdContains(params int[] values) {
            return new DirectSpecification<Proposta>(p => values.Contains(p.Id));
        }
		public static Specification<Proposta> IdNotContains(params int[] values) {
            return new DirectSpecification<Proposta>(p => !values.Contains(p.Id));
        }
		public static Specification<Proposta> IdEqual(params int[] values) {
			return new DirectSpecification<Proposta>(p => values.Contains(p.Id));
        }
        public static Specification<Proposta> IdGreaterThanOrEqual(int value) {
            return new DirectSpecification<Proposta>(p => p.Id >= value);
        }
        public static Specification<Proposta> IdLessThanOrEqual(int value) {
            return new DirectSpecification<Proposta>(p => p.Id <= value);
        }
        public static Specification<Proposta> IdNotEqual(int value) {
            return new DirectSpecification<Proposta>(p => p.Id != value);
        }
        public static Specification<Proposta> IdGreaterThan(int value) {
            return new DirectSpecification<Proposta>(p => p.Id > value);
        }
        public static Specification<Proposta> IdLessThan(int value) {
            return new DirectSpecification<Proposta>(p => p.Id < value);
        }
		
					public static Specification<Proposta> DeletadoEqual(bool value) {
			return new DirectSpecification<Proposta>(p => p.Deletado == value);
		}
		
	   }
