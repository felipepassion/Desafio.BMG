
namespace Bmg.Desafio.Proposta.Domain.Aggregates.PropostaAgg.Filters;

using Bmg.Desafio.CrossCuting.Infra.Utils.Extensions;
using System.Linq.Expressions;
using Bmg.Desafio.Core.Domain.Seedwork.Specification;
using Entities;
using Specifications;
using Queries.Models;

	public static class PropostaFilters 
	{
	    public static Expression<Func<Proposta, bool>> GetFilters(this PropostaQueryModel request, bool isOrSpecification = false)

		{ return request.GetFiltersSpecification(isOrSpecification).SatisfiedBy(); }
		public static Specification<Proposta> GetFiltersSpecification(this PropostaQueryModel request, bool isOrSpecification = false) 
		{
			isOrSpecification = request.IsOrSpecification;
			Specification<Proposta> filter = new DirectSpecification<Proposta>(p => request.IsEmpty() || !isOrSpecification);
			if(request is not null)
			{
				if (request.UserIdEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UserIdEqual(request.UserIdEqual.Value);
					else
						filter &= PropostaSpecifications.UserIdEqual(request.UserIdEqual.Value);
				}
				if (request.UserIdNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UserIdNotEqual(request.UserIdNotEqual.Value);
					else
						filter &= PropostaSpecifications.UserIdNotEqual(request.UserIdNotEqual.Value);
				}
				if (request.UserIdContains != null)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UserIdContains(request.UserIdContains);
					else
						filter &= PropostaSpecifications.UserIdContains(request.UserIdContains);
				}
				if (request.UserIdNotContains != null)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UserIdNotContains(request.UserIdNotContains);
					else
						filter &= PropostaSpecifications.UserIdNotContains(request.UserIdNotContains);
				}
				if (request.UserIdSince.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UserIdGreaterThanOrEqual(request.UserIdSince.Value);
					else
						filter &= PropostaSpecifications.UserIdGreaterThanOrEqual(request.UserIdSince.Value);
				}
				if (request.UserIdUntil.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UserIdLessThan(request.UserIdUntil.Value);
					else
						filter &= PropostaSpecifications.UserIdLessThan(request.UserIdUntil.Value);
				}
				if (request.UserIdNotEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UserIdNotEqual(request.UserIdNotEqual.Value);
					else
						filter &= PropostaSpecifications.UserIdNotEqual(request.UserIdNotEqual.Value);
				}
				if (request.UserIdLessThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UserIdLessThan(request.UserIdLessThan.Value);
					else
						filter &= PropostaSpecifications.UserIdLessThan(request.UserIdLessThan.Value);
				}
				if (request.UserIdGreaterThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UserIdGreaterThan(request.UserIdGreaterThan.Value);
					else
						filter &= PropostaSpecifications.UserIdGreaterThan(request.UserIdGreaterThan.Value);
				}
				if (request.UserIdLessThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UserIdLessThanOrEqual(request.UserIdLessThanOrEqual.Value);
					else
						filter &= PropostaSpecifications.UserIdLessThanOrEqual(request.UserIdLessThanOrEqual.Value);
				}
				if (request.UserIdGreaterThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UserIdGreaterThanOrEqual(request.UserIdGreaterThanOrEqual.Value);
					else
						filter &= PropostaSpecifications.UserIdGreaterThanOrEqual(request.UserIdGreaterThanOrEqual.Value);
				}
				if (request.StatusEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.StatusEqual(request.StatusEqual.Value);
					else
						filter &= PropostaSpecifications.StatusEqual(request.StatusEqual.Value);
				}
				if (request.ValorCoberturaEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.ValorCoberturaEqual(request.ValorCoberturaEqual.Value);
					else
						filter &= PropostaSpecifications.ValorCoberturaEqual(request.ValorCoberturaEqual.Value);
				}
				if (request.ValorCoberturaNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.ValorCoberturaNotEqual(request.ValorCoberturaNotEqual.Value);
					else
						filter &= PropostaSpecifications.ValorCoberturaNotEqual(request.ValorCoberturaNotEqual.Value);
				}
				if (request.ValorCoberturaContains != null)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.ValorCoberturaContains(request.ValorCoberturaContains);
					else
						filter &= PropostaSpecifications.ValorCoberturaContains(request.ValorCoberturaContains);
				}
				if (request.ValorCoberturaNotContains != null)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.ValorCoberturaNotContains(request.ValorCoberturaNotContains);
					else
						filter &= PropostaSpecifications.ValorCoberturaNotContains(request.ValorCoberturaNotContains);
				}
				if (request.ValorCoberturaSince.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.ValorCoberturaGreaterThanOrEqual(request.ValorCoberturaSince.Value);
					else
						filter &= PropostaSpecifications.ValorCoberturaGreaterThanOrEqual(request.ValorCoberturaSince.Value);
				}
				if (request.ValorCoberturaUntil.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.ValorCoberturaLessThan(request.ValorCoberturaUntil.Value);
					else
						filter &= PropostaSpecifications.ValorCoberturaLessThan(request.ValorCoberturaUntil.Value);
				}
				if (request.ValorCoberturaNotEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.ValorCoberturaNotEqual(request.ValorCoberturaNotEqual.Value);
					else
						filter &= PropostaSpecifications.ValorCoberturaNotEqual(request.ValorCoberturaNotEqual.Value);
				}
				if (request.ValorCoberturaLessThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.ValorCoberturaLessThan(request.ValorCoberturaLessThan.Value);
					else
						filter &= PropostaSpecifications.ValorCoberturaLessThan(request.ValorCoberturaLessThan.Value);
				}
				if (request.ValorCoberturaGreaterThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.ValorCoberturaGreaterThan(request.ValorCoberturaGreaterThan.Value);
					else
						filter &= PropostaSpecifications.ValorCoberturaGreaterThan(request.ValorCoberturaGreaterThan.Value);
				}
				if (request.ValorCoberturaLessThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.ValorCoberturaLessThanOrEqual(request.ValorCoberturaLessThanOrEqual.Value);
					else
						filter &= PropostaSpecifications.ValorCoberturaLessThanOrEqual(request.ValorCoberturaLessThanOrEqual.Value);
				}
				if (request.ValorCoberturaGreaterThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.ValorCoberturaGreaterThanOrEqual(request.ValorCoberturaGreaterThanOrEqual.Value);
					else
						filter &= PropostaSpecifications.ValorCoberturaGreaterThanOrEqual(request.ValorCoberturaGreaterThanOrEqual.Value);
				}
				if (!string.IsNullOrWhiteSpace(request.MotivoRejeicaoEqual)) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.MotivoRejeicaoEqual(request.MotivoRejeicaoEqual);
					else
						filter &= PropostaSpecifications.MotivoRejeicaoEqual(request.MotivoRejeicaoEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.MotivoRejeicaoNotEqual)) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.MotivoRejeicaoNotEqual(request.MotivoRejeicaoNotEqual);
					else
						filter &= PropostaSpecifications.MotivoRejeicaoNotEqual(request.MotivoRejeicaoNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.MotivoRejeicaoNotEqual)) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.MotivoRejeicaoNotEqual(request.MotivoRejeicaoNotEqual);
					else
						filter &= PropostaSpecifications.MotivoRejeicaoNotEqual(request.MotivoRejeicaoNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.MotivoRejeicaoContains)) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.MotivoRejeicaoContains(request.MotivoRejeicaoContains);
					else
						filter &= PropostaSpecifications.MotivoRejeicaoContains(request.MotivoRejeicaoContains);
				}
				if (!string.IsNullOrWhiteSpace(request.MotivoRejeicaoStartsWith)) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.MotivoRejeicaoStartsWith(request.MotivoRejeicaoStartsWith);
					else
						filter &= PropostaSpecifications.MotivoRejeicaoStartsWith(request.MotivoRejeicaoStartsWith);
				}
				if (request.DataAprovacaoEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataAprovacaoEqual(request.DataAprovacaoEqual.Value);
					else
						filter &= PropostaSpecifications.DataAprovacaoEqual(request.DataAprovacaoEqual.Value);
				}
				if (request.DataAprovacaoNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataAprovacaoNotEqual(request.DataAprovacaoNotEqual.Value);
					else
						filter &= PropostaSpecifications.DataAprovacaoNotEqual(request.DataAprovacaoNotEqual.Value);
				}
				if (request.DataAprovacaoContains != null)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataAprovacaoContains(request.DataAprovacaoContains);
					else
						filter &= PropostaSpecifications.DataAprovacaoContains(request.DataAprovacaoContains);
				}
				if (request.DataAprovacaoNotContains != null)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataAprovacaoNotContains(request.DataAprovacaoNotContains);
					else
						filter &= PropostaSpecifications.DataAprovacaoNotContains(request.DataAprovacaoNotContains);
				}
				if (request.DataAprovacaoSince.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataAprovacaoGreaterThanOrEqual(request.DataAprovacaoSince.Value);
					else
						filter &= PropostaSpecifications.DataAprovacaoGreaterThanOrEqual(request.DataAprovacaoSince.Value);
				}
				if (request.DataAprovacaoUntil.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataAprovacaoLessThan(request.DataAprovacaoUntil.Value);
					else
						filter &= PropostaSpecifications.DataAprovacaoLessThan(request.DataAprovacaoUntil.Value);
				}
				if (request.DataAprovacaoNotEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataAprovacaoNotEqual(request.DataAprovacaoNotEqual.Value);
					else
						filter &= PropostaSpecifications.DataAprovacaoNotEqual(request.DataAprovacaoNotEqual.Value);
				}
				if (request.DataAprovacaoLessThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataAprovacaoLessThan(request.DataAprovacaoLessThan.Value);
					else
						filter &= PropostaSpecifications.DataAprovacaoLessThan(request.DataAprovacaoLessThan.Value);
				}
				if (request.DataAprovacaoGreaterThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataAprovacaoGreaterThan(request.DataAprovacaoGreaterThan.Value);
					else
						filter &= PropostaSpecifications.DataAprovacaoGreaterThan(request.DataAprovacaoGreaterThan.Value);
				}
				if (request.DataAprovacaoLessThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataAprovacaoLessThanOrEqual(request.DataAprovacaoLessThanOrEqual.Value);
					else
						filter &= PropostaSpecifications.DataAprovacaoLessThanOrEqual(request.DataAprovacaoLessThanOrEqual.Value);
				}
				if (request.DataAprovacaoGreaterThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataAprovacaoGreaterThanOrEqual(request.DataAprovacaoGreaterThanOrEqual.Value);
					else
						filter &= PropostaSpecifications.DataAprovacaoGreaterThanOrEqual(request.DataAprovacaoGreaterThanOrEqual.Value);
				}
				if (request.DataRejeicaoEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataRejeicaoEqual(request.DataRejeicaoEqual.Value);
					else
						filter &= PropostaSpecifications.DataRejeicaoEqual(request.DataRejeicaoEqual.Value);
				}
				if (request.DataRejeicaoNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataRejeicaoNotEqual(request.DataRejeicaoNotEqual.Value);
					else
						filter &= PropostaSpecifications.DataRejeicaoNotEqual(request.DataRejeicaoNotEqual.Value);
				}
				if (request.DataRejeicaoContains != null)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataRejeicaoContains(request.DataRejeicaoContains);
					else
						filter &= PropostaSpecifications.DataRejeicaoContains(request.DataRejeicaoContains);
				}
				if (request.DataRejeicaoNotContains != null)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataRejeicaoNotContains(request.DataRejeicaoNotContains);
					else
						filter &= PropostaSpecifications.DataRejeicaoNotContains(request.DataRejeicaoNotContains);
				}
				if (request.DataRejeicaoSince.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataRejeicaoGreaterThanOrEqual(request.DataRejeicaoSince.Value);
					else
						filter &= PropostaSpecifications.DataRejeicaoGreaterThanOrEqual(request.DataRejeicaoSince.Value);
				}
				if (request.DataRejeicaoUntil.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataRejeicaoLessThan(request.DataRejeicaoUntil.Value);
					else
						filter &= PropostaSpecifications.DataRejeicaoLessThan(request.DataRejeicaoUntil.Value);
				}
				if (request.DataRejeicaoNotEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataRejeicaoNotEqual(request.DataRejeicaoNotEqual.Value);
					else
						filter &= PropostaSpecifications.DataRejeicaoNotEqual(request.DataRejeicaoNotEqual.Value);
				}
				if (request.DataRejeicaoLessThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataRejeicaoLessThan(request.DataRejeicaoLessThan.Value);
					else
						filter &= PropostaSpecifications.DataRejeicaoLessThan(request.DataRejeicaoLessThan.Value);
				}
				if (request.DataRejeicaoGreaterThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataRejeicaoGreaterThan(request.DataRejeicaoGreaterThan.Value);
					else
						filter &= PropostaSpecifications.DataRejeicaoGreaterThan(request.DataRejeicaoGreaterThan.Value);
				}
				if (request.DataRejeicaoLessThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataRejeicaoLessThanOrEqual(request.DataRejeicaoLessThanOrEqual.Value);
					else
						filter &= PropostaSpecifications.DataRejeicaoLessThanOrEqual(request.DataRejeicaoLessThanOrEqual.Value);
				}
				if (request.DataRejeicaoGreaterThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DataRejeicaoGreaterThanOrEqual(request.DataRejeicaoGreaterThanOrEqual.Value);
					else
						filter &= PropostaSpecifications.DataRejeicaoGreaterThanOrEqual(request.DataRejeicaoGreaterThanOrEqual.Value);
				}
				if (request.ContratadaEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.ContratadaEqual(request.ContratadaEqual.Value);
					else
						filter &= PropostaSpecifications.ContratadaEqual(request.ContratadaEqual.Value);
				}
				if (!string.IsNullOrWhiteSpace(request.ExternalIdEqual)) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.ExternalIdEqual(request.ExternalIdEqual);
					else
						filter &= PropostaSpecifications.ExternalIdEqual(request.ExternalIdEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.ExternalIdNotEqual)) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.ExternalIdNotEqual(request.ExternalIdNotEqual);
					else
						filter &= PropostaSpecifications.ExternalIdNotEqual(request.ExternalIdNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.ExternalIdNotEqual)) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.ExternalIdNotEqual(request.ExternalIdNotEqual);
					else
						filter &= PropostaSpecifications.ExternalIdNotEqual(request.ExternalIdNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.ExternalIdContains)) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.ExternalIdContains(request.ExternalIdContains);
					else
						filter &= PropostaSpecifications.ExternalIdContains(request.ExternalIdContains);
				}
				if (!string.IsNullOrWhiteSpace(request.ExternalIdStartsWith)) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.ExternalIdStartsWith(request.ExternalIdStartsWith);
					else
						filter &= PropostaSpecifications.ExternalIdStartsWith(request.ExternalIdStartsWith);
				}
				if (request.CreatedAtEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.CreatedAtEqual(request.CreatedAtEqual.Value);
					else
						filter &= PropostaSpecifications.CreatedAtEqual(request.CreatedAtEqual.Value);
				}
				if (request.CreatedAtNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.CreatedAtNotEqual(request.CreatedAtNotEqual.Value);
					else
						filter &= PropostaSpecifications.CreatedAtNotEqual(request.CreatedAtNotEqual.Value);
				}
				if (request.CreatedAtContains != null)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.CreatedAtContains(request.CreatedAtContains);
					else
						filter &= PropostaSpecifications.CreatedAtContains(request.CreatedAtContains);
				}
				if (request.CreatedAtNotContains != null)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.CreatedAtNotContains(request.CreatedAtNotContains);
					else
						filter &= PropostaSpecifications.CreatedAtNotContains(request.CreatedAtNotContains);
				}
				if (request.CreatedAtSince.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.CreatedAtGreaterThanOrEqual(request.CreatedAtSince.Value);
					else
						filter &= PropostaSpecifications.CreatedAtGreaterThanOrEqual(request.CreatedAtSince.Value);
				}
				if (request.CreatedAtUntil.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.CreatedAtLessThan(request.CreatedAtUntil.Value);
					else
						filter &= PropostaSpecifications.CreatedAtLessThan(request.CreatedAtUntil.Value);
				}
				if (request.CreatedAtNotEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.CreatedAtNotEqual(request.CreatedAtNotEqual.Value);
					else
						filter &= PropostaSpecifications.CreatedAtNotEqual(request.CreatedAtNotEqual.Value);
				}
				if (request.CreatedAtLessThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.CreatedAtLessThan(request.CreatedAtLessThan.Value);
					else
						filter &= PropostaSpecifications.CreatedAtLessThan(request.CreatedAtLessThan.Value);
				}
				if (request.CreatedAtGreaterThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.CreatedAtGreaterThan(request.CreatedAtGreaterThan.Value);
					else
						filter &= PropostaSpecifications.CreatedAtGreaterThan(request.CreatedAtGreaterThan.Value);
				}
				if (request.CreatedAtLessThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.CreatedAtLessThanOrEqual(request.CreatedAtLessThanOrEqual.Value);
					else
						filter &= PropostaSpecifications.CreatedAtLessThanOrEqual(request.CreatedAtLessThanOrEqual.Value);
				}
				if (request.CreatedAtGreaterThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.CreatedAtGreaterThanOrEqual(request.CreatedAtGreaterThanOrEqual.Value);
					else
						filter &= PropostaSpecifications.CreatedAtGreaterThanOrEqual(request.CreatedAtGreaterThanOrEqual.Value);
				}
				if (request.UpdatedAtEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UpdatedAtEqual(request.UpdatedAtEqual.Value);
					else
						filter &= PropostaSpecifications.UpdatedAtEqual(request.UpdatedAtEqual.Value);
				}
				if (request.UpdatedAtNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UpdatedAtNotEqual(request.UpdatedAtNotEqual.Value);
					else
						filter &= PropostaSpecifications.UpdatedAtNotEqual(request.UpdatedAtNotEqual.Value);
				}
				if (request.UpdatedAtContains != null)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UpdatedAtContains(request.UpdatedAtContains);
					else
						filter &= PropostaSpecifications.UpdatedAtContains(request.UpdatedAtContains);
				}
				if (request.UpdatedAtNotContains != null)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UpdatedAtNotContains(request.UpdatedAtNotContains);
					else
						filter &= PropostaSpecifications.UpdatedAtNotContains(request.UpdatedAtNotContains);
				}
				if (request.UpdatedAtSince.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UpdatedAtGreaterThanOrEqual(request.UpdatedAtSince.Value);
					else
						filter &= PropostaSpecifications.UpdatedAtGreaterThanOrEqual(request.UpdatedAtSince.Value);
				}
				if (request.UpdatedAtUntil.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UpdatedAtLessThan(request.UpdatedAtUntil.Value);
					else
						filter &= PropostaSpecifications.UpdatedAtLessThan(request.UpdatedAtUntil.Value);
				}
				if (request.UpdatedAtNotEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UpdatedAtNotEqual(request.UpdatedAtNotEqual.Value);
					else
						filter &= PropostaSpecifications.UpdatedAtNotEqual(request.UpdatedAtNotEqual.Value);
				}
				if (request.UpdatedAtLessThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UpdatedAtLessThan(request.UpdatedAtLessThan.Value);
					else
						filter &= PropostaSpecifications.UpdatedAtLessThan(request.UpdatedAtLessThan.Value);
				}
				if (request.UpdatedAtGreaterThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UpdatedAtGreaterThan(request.UpdatedAtGreaterThan.Value);
					else
						filter &= PropostaSpecifications.UpdatedAtGreaterThan(request.UpdatedAtGreaterThan.Value);
				}
				if (request.UpdatedAtLessThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UpdatedAtLessThanOrEqual(request.UpdatedAtLessThanOrEqual.Value);
					else
						filter &= PropostaSpecifications.UpdatedAtLessThanOrEqual(request.UpdatedAtLessThanOrEqual.Value);
				}
				if (request.UpdatedAtGreaterThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.UpdatedAtGreaterThanOrEqual(request.UpdatedAtGreaterThanOrEqual.Value);
					else
						filter &= PropostaSpecifications.UpdatedAtGreaterThanOrEqual(request.UpdatedAtGreaterThanOrEqual.Value);
				}
				if (request.DeletedAtEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DeletedAtEqual(request.DeletedAtEqual.Value);
					else
						filter &= PropostaSpecifications.DeletedAtEqual(request.DeletedAtEqual.Value);
				}
				if (request.DeletedAtNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DeletedAtNotEqual(request.DeletedAtNotEqual.Value);
					else
						filter &= PropostaSpecifications.DeletedAtNotEqual(request.DeletedAtNotEqual.Value);
				}
				if (request.DeletedAtContains != null)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DeletedAtContains(request.DeletedAtContains);
					else
						filter &= PropostaSpecifications.DeletedAtContains(request.DeletedAtContains);
				}
				if (request.DeletedAtNotContains != null)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DeletedAtNotContains(request.DeletedAtNotContains);
					else
						filter &= PropostaSpecifications.DeletedAtNotContains(request.DeletedAtNotContains);
				}
				if (request.DeletedAtSince.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DeletedAtGreaterThanOrEqual(request.DeletedAtSince.Value);
					else
						filter &= PropostaSpecifications.DeletedAtGreaterThanOrEqual(request.DeletedAtSince.Value);
				}
				if (request.DeletedAtUntil.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DeletedAtLessThan(request.DeletedAtUntil.Value);
					else
						filter &= PropostaSpecifications.DeletedAtLessThan(request.DeletedAtUntil.Value);
				}
				if (request.DeletedAtNotEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DeletedAtNotEqual(request.DeletedAtNotEqual.Value);
					else
						filter &= PropostaSpecifications.DeletedAtNotEqual(request.DeletedAtNotEqual.Value);
				}
				if (request.DeletedAtLessThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DeletedAtLessThan(request.DeletedAtLessThan.Value);
					else
						filter &= PropostaSpecifications.DeletedAtLessThan(request.DeletedAtLessThan.Value);
				}
				if (request.DeletedAtGreaterThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DeletedAtGreaterThan(request.DeletedAtGreaterThan.Value);
					else
						filter &= PropostaSpecifications.DeletedAtGreaterThan(request.DeletedAtGreaterThan.Value);
				}
				if (request.DeletedAtLessThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DeletedAtLessThanOrEqual(request.DeletedAtLessThanOrEqual.Value);
					else
						filter &= PropostaSpecifications.DeletedAtLessThanOrEqual(request.DeletedAtLessThanOrEqual.Value);
				}
				if (request.DeletedAtGreaterThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DeletedAtGreaterThanOrEqual(request.DeletedAtGreaterThanOrEqual.Value);
					else
						filter &= PropostaSpecifications.DeletedAtGreaterThanOrEqual(request.DeletedAtGreaterThanOrEqual.Value);
				}
				if (request.IdEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.IdEqual(request.IdEqual.Value);
					else
						filter &= PropostaSpecifications.IdEqual(request.IdEqual.Value);
				}
				if (request.IdNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.IdNotEqual(request.IdNotEqual.Value);
					else
						filter &= PropostaSpecifications.IdNotEqual(request.IdNotEqual.Value);
				}
				if (request.IdContains != null)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.IdContains(request.IdContains);
					else
						filter &= PropostaSpecifications.IdContains(request.IdContains);
				}
				if (request.IdNotContains != null)
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.IdNotContains(request.IdNotContains);
					else
						filter &= PropostaSpecifications.IdNotContains(request.IdNotContains);
				}
				if (request.DeletadoEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= PropostaSpecifications.DeletadoEqual(request.DeletadoEqual.Value);
					else
						filter &= PropostaSpecifications.DeletadoEqual(request.DeletadoEqual.Value);
				}
			}
			return filter;
		}
	}
