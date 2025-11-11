
namespace Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Filters;

using Bmg.Desafio.CrossCuting.Infra.Utils.Extensions;
using System.Linq.Expressions;
using Bmg.Desafio.Core.Domain.Seedwork.Specification;
using Entities;
using Specifications;
using Queries.Models;

	public static class ContratoFilters 
	{
	    public static Expression<Func<Contrato, bool>> GetFilters(this ContratoQueryModel request, bool isOrSpecification = false)

		{ return request.GetFiltersSpecification(isOrSpecification).SatisfiedBy(); }
		public static Specification<Contrato> GetFiltersSpecification(this ContratoQueryModel request, bool isOrSpecification = false) 
		{
			isOrSpecification = request.IsOrSpecification;
			Specification<Contrato> filter = new DirectSpecification<Contrato>(p => request.IsEmpty() || !isOrSpecification);
			if(request is not null)
			{
				if (request.PropostaIdEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.PropostaIdEqual(request.PropostaIdEqual.Value);
					else
						filter &= ContratoSpecifications.PropostaIdEqual(request.PropostaIdEqual.Value);
				}
				if (request.PropostaIdNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.PropostaIdNotEqual(request.PropostaIdNotEqual.Value);
					else
						filter &= ContratoSpecifications.PropostaIdNotEqual(request.PropostaIdNotEqual.Value);
				}
				if (request.PropostaIdContains != null)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.PropostaIdContains(request.PropostaIdContains);
					else
						filter &= ContratoSpecifications.PropostaIdContains(request.PropostaIdContains);
				}
				if (request.PropostaIdNotContains != null)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.PropostaIdNotContains(request.PropostaIdNotContains);
					else
						filter &= ContratoSpecifications.PropostaIdNotContains(request.PropostaIdNotContains);
				}
				if (request.PropostaIdSince.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.PropostaIdGreaterThanOrEqual(request.PropostaIdSince.Value);
					else
						filter &= ContratoSpecifications.PropostaIdGreaterThanOrEqual(request.PropostaIdSince.Value);
				}
				if (request.PropostaIdUntil.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.PropostaIdLessThan(request.PropostaIdUntil.Value);
					else
						filter &= ContratoSpecifications.PropostaIdLessThan(request.PropostaIdUntil.Value);
				}
				if (request.PropostaIdNotEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.PropostaIdNotEqual(request.PropostaIdNotEqual.Value);
					else
						filter &= ContratoSpecifications.PropostaIdNotEqual(request.PropostaIdNotEqual.Value);
				}
				if (request.PropostaIdLessThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.PropostaIdLessThan(request.PropostaIdLessThan.Value);
					else
						filter &= ContratoSpecifications.PropostaIdLessThan(request.PropostaIdLessThan.Value);
				}
				if (request.PropostaIdGreaterThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.PropostaIdGreaterThan(request.PropostaIdGreaterThan.Value);
					else
						filter &= ContratoSpecifications.PropostaIdGreaterThan(request.PropostaIdGreaterThan.Value);
				}
				if (request.PropostaIdLessThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.PropostaIdLessThanOrEqual(request.PropostaIdLessThanOrEqual.Value);
					else
						filter &= ContratoSpecifications.PropostaIdLessThanOrEqual(request.PropostaIdLessThanOrEqual.Value);
				}
				if (request.PropostaIdGreaterThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.PropostaIdGreaterThanOrEqual(request.PropostaIdGreaterThanOrEqual.Value);
					else
						filter &= ContratoSpecifications.PropostaIdGreaterThanOrEqual(request.PropostaIdGreaterThanOrEqual.Value);
				}
				if (!string.IsNullOrWhiteSpace(request.NumeroContratoEqual)) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.NumeroContratoEqual(request.NumeroContratoEqual);
					else
						filter &= ContratoSpecifications.NumeroContratoEqual(request.NumeroContratoEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.NumeroContratoNotEqual)) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.NumeroContratoNotEqual(request.NumeroContratoNotEqual);
					else
						filter &= ContratoSpecifications.NumeroContratoNotEqual(request.NumeroContratoNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.NumeroContratoNotEqual)) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.NumeroContratoNotEqual(request.NumeroContratoNotEqual);
					else
						filter &= ContratoSpecifications.NumeroContratoNotEqual(request.NumeroContratoNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.NumeroContratoContains)) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.NumeroContratoContains(request.NumeroContratoContains);
					else
						filter &= ContratoSpecifications.NumeroContratoContains(request.NumeroContratoContains);
				}
				if (!string.IsNullOrWhiteSpace(request.NumeroContratoStartsWith)) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.NumeroContratoStartsWith(request.NumeroContratoStartsWith);
					else
						filter &= ContratoSpecifications.NumeroContratoStartsWith(request.NumeroContratoStartsWith);
				}
				if (request.DataContratacaoEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataContratacaoEqual(request.DataContratacaoEqual.Value);
					else
						filter &= ContratoSpecifications.DataContratacaoEqual(request.DataContratacaoEqual.Value);
				}
				if (request.DataContratacaoNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataContratacaoNotEqual(request.DataContratacaoNotEqual.Value);
					else
						filter &= ContratoSpecifications.DataContratacaoNotEqual(request.DataContratacaoNotEqual.Value);
				}
				if (request.DataContratacaoContains != null)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataContratacaoContains(request.DataContratacaoContains);
					else
						filter &= ContratoSpecifications.DataContratacaoContains(request.DataContratacaoContains);
				}
				if (request.DataContratacaoNotContains != null)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataContratacaoNotContains(request.DataContratacaoNotContains);
					else
						filter &= ContratoSpecifications.DataContratacaoNotContains(request.DataContratacaoNotContains);
				}
				if (request.DataContratacaoSince.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataContratacaoGreaterThanOrEqual(request.DataContratacaoSince.Value);
					else
						filter &= ContratoSpecifications.DataContratacaoGreaterThanOrEqual(request.DataContratacaoSince.Value);
				}
				if (request.DataContratacaoUntil.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataContratacaoLessThan(request.DataContratacaoUntil.Value);
					else
						filter &= ContratoSpecifications.DataContratacaoLessThan(request.DataContratacaoUntil.Value);
				}
				if (request.DataContratacaoNotEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataContratacaoNotEqual(request.DataContratacaoNotEqual.Value);
					else
						filter &= ContratoSpecifications.DataContratacaoNotEqual(request.DataContratacaoNotEqual.Value);
				}
				if (request.DataContratacaoLessThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataContratacaoLessThan(request.DataContratacaoLessThan.Value);
					else
						filter &= ContratoSpecifications.DataContratacaoLessThan(request.DataContratacaoLessThan.Value);
				}
				if (request.DataContratacaoGreaterThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataContratacaoGreaterThan(request.DataContratacaoGreaterThan.Value);
					else
						filter &= ContratoSpecifications.DataContratacaoGreaterThan(request.DataContratacaoGreaterThan.Value);
				}
				if (request.DataContratacaoLessThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataContratacaoLessThanOrEqual(request.DataContratacaoLessThanOrEqual.Value);
					else
						filter &= ContratoSpecifications.DataContratacaoLessThanOrEqual(request.DataContratacaoLessThanOrEqual.Value);
				}
				if (request.DataContratacaoGreaterThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataContratacaoGreaterThanOrEqual(request.DataContratacaoGreaterThanOrEqual.Value);
					else
						filter &= ContratoSpecifications.DataContratacaoGreaterThanOrEqual(request.DataContratacaoGreaterThanOrEqual.Value);
				}
				if (request.InicioVigenciaEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.InicioVigenciaEqual(request.InicioVigenciaEqual.Value);
					else
						filter &= ContratoSpecifications.InicioVigenciaEqual(request.InicioVigenciaEqual.Value);
				}
				if (request.InicioVigenciaNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.InicioVigenciaNotEqual(request.InicioVigenciaNotEqual.Value);
					else
						filter &= ContratoSpecifications.InicioVigenciaNotEqual(request.InicioVigenciaNotEqual.Value);
				}
				if (request.InicioVigenciaContains != null)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.InicioVigenciaContains(request.InicioVigenciaContains);
					else
						filter &= ContratoSpecifications.InicioVigenciaContains(request.InicioVigenciaContains);
				}
				if (request.InicioVigenciaNotContains != null)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.InicioVigenciaNotContains(request.InicioVigenciaNotContains);
					else
						filter &= ContratoSpecifications.InicioVigenciaNotContains(request.InicioVigenciaNotContains);
				}
				if (request.InicioVigenciaSince.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.InicioVigenciaGreaterThanOrEqual(request.InicioVigenciaSince.Value);
					else
						filter &= ContratoSpecifications.InicioVigenciaGreaterThanOrEqual(request.InicioVigenciaSince.Value);
				}
				if (request.InicioVigenciaUntil.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.InicioVigenciaLessThan(request.InicioVigenciaUntil.Value);
					else
						filter &= ContratoSpecifications.InicioVigenciaLessThan(request.InicioVigenciaUntil.Value);
				}
				if (request.InicioVigenciaNotEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.InicioVigenciaNotEqual(request.InicioVigenciaNotEqual.Value);
					else
						filter &= ContratoSpecifications.InicioVigenciaNotEqual(request.InicioVigenciaNotEqual.Value);
				}
				if (request.InicioVigenciaLessThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.InicioVigenciaLessThan(request.InicioVigenciaLessThan.Value);
					else
						filter &= ContratoSpecifications.InicioVigenciaLessThan(request.InicioVigenciaLessThan.Value);
				}
				if (request.InicioVigenciaGreaterThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.InicioVigenciaGreaterThan(request.InicioVigenciaGreaterThan.Value);
					else
						filter &= ContratoSpecifications.InicioVigenciaGreaterThan(request.InicioVigenciaGreaterThan.Value);
				}
				if (request.InicioVigenciaLessThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.InicioVigenciaLessThanOrEqual(request.InicioVigenciaLessThanOrEqual.Value);
					else
						filter &= ContratoSpecifications.InicioVigenciaLessThanOrEqual(request.InicioVigenciaLessThanOrEqual.Value);
				}
				if (request.InicioVigenciaGreaterThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.InicioVigenciaGreaterThanOrEqual(request.InicioVigenciaGreaterThanOrEqual.Value);
					else
						filter &= ContratoSpecifications.InicioVigenciaGreaterThanOrEqual(request.InicioVigenciaGreaterThanOrEqual.Value);
				}
				if (request.FimVigenciaEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.FimVigenciaEqual(request.FimVigenciaEqual.Value);
					else
						filter &= ContratoSpecifications.FimVigenciaEqual(request.FimVigenciaEqual.Value);
				}
				if (request.FimVigenciaNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.FimVigenciaNotEqual(request.FimVigenciaNotEqual.Value);
					else
						filter &= ContratoSpecifications.FimVigenciaNotEqual(request.FimVigenciaNotEqual.Value);
				}
				if (request.FimVigenciaContains != null)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.FimVigenciaContains(request.FimVigenciaContains);
					else
						filter &= ContratoSpecifications.FimVigenciaContains(request.FimVigenciaContains);
				}
				if (request.FimVigenciaNotContains != null)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.FimVigenciaNotContains(request.FimVigenciaNotContains);
					else
						filter &= ContratoSpecifications.FimVigenciaNotContains(request.FimVigenciaNotContains);
				}
				if (request.FimVigenciaSince.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.FimVigenciaGreaterThanOrEqual(request.FimVigenciaSince.Value);
					else
						filter &= ContratoSpecifications.FimVigenciaGreaterThanOrEqual(request.FimVigenciaSince.Value);
				}
				if (request.FimVigenciaUntil.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.FimVigenciaLessThan(request.FimVigenciaUntil.Value);
					else
						filter &= ContratoSpecifications.FimVigenciaLessThan(request.FimVigenciaUntil.Value);
				}
				if (request.FimVigenciaNotEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.FimVigenciaNotEqual(request.FimVigenciaNotEqual.Value);
					else
						filter &= ContratoSpecifications.FimVigenciaNotEqual(request.FimVigenciaNotEqual.Value);
				}
				if (request.FimVigenciaLessThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.FimVigenciaLessThan(request.FimVigenciaLessThan.Value);
					else
						filter &= ContratoSpecifications.FimVigenciaLessThan(request.FimVigenciaLessThan.Value);
				}
				if (request.FimVigenciaGreaterThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.FimVigenciaGreaterThan(request.FimVigenciaGreaterThan.Value);
					else
						filter &= ContratoSpecifications.FimVigenciaGreaterThan(request.FimVigenciaGreaterThan.Value);
				}
				if (request.FimVigenciaLessThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.FimVigenciaLessThanOrEqual(request.FimVigenciaLessThanOrEqual.Value);
					else
						filter &= ContratoSpecifications.FimVigenciaLessThanOrEqual(request.FimVigenciaLessThanOrEqual.Value);
				}
				if (request.FimVigenciaGreaterThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.FimVigenciaGreaterThanOrEqual(request.FimVigenciaGreaterThanOrEqual.Value);
					else
						filter &= ContratoSpecifications.FimVigenciaGreaterThanOrEqual(request.FimVigenciaGreaterThanOrEqual.Value);
				}
				if (request.StatusEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.StatusEqual(request.StatusEqual.Value);
					else
						filter &= ContratoSpecifications.StatusEqual(request.StatusEqual.Value);
				}
				if (!string.IsNullOrWhiteSpace(request.MotivoCancelamentoEqual)) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.MotivoCancelamentoEqual(request.MotivoCancelamentoEqual);
					else
						filter &= ContratoSpecifications.MotivoCancelamentoEqual(request.MotivoCancelamentoEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.MotivoCancelamentoNotEqual)) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.MotivoCancelamentoNotEqual(request.MotivoCancelamentoNotEqual);
					else
						filter &= ContratoSpecifications.MotivoCancelamentoNotEqual(request.MotivoCancelamentoNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.MotivoCancelamentoNotEqual)) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.MotivoCancelamentoNotEqual(request.MotivoCancelamentoNotEqual);
					else
						filter &= ContratoSpecifications.MotivoCancelamentoNotEqual(request.MotivoCancelamentoNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.MotivoCancelamentoContains)) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.MotivoCancelamentoContains(request.MotivoCancelamentoContains);
					else
						filter &= ContratoSpecifications.MotivoCancelamentoContains(request.MotivoCancelamentoContains);
				}
				if (!string.IsNullOrWhiteSpace(request.MotivoCancelamentoStartsWith)) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.MotivoCancelamentoStartsWith(request.MotivoCancelamentoStartsWith);
					else
						filter &= ContratoSpecifications.MotivoCancelamentoStartsWith(request.MotivoCancelamentoStartsWith);
				}
				if (request.DataCancelamentoEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataCancelamentoEqual(request.DataCancelamentoEqual.Value);
					else
						filter &= ContratoSpecifications.DataCancelamentoEqual(request.DataCancelamentoEqual.Value);
				}
				if (request.DataCancelamentoNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataCancelamentoNotEqual(request.DataCancelamentoNotEqual.Value);
					else
						filter &= ContratoSpecifications.DataCancelamentoNotEqual(request.DataCancelamentoNotEqual.Value);
				}
				if (request.DataCancelamentoContains != null)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataCancelamentoContains(request.DataCancelamentoContains);
					else
						filter &= ContratoSpecifications.DataCancelamentoContains(request.DataCancelamentoContains);
				}
				if (request.DataCancelamentoNotContains != null)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataCancelamentoNotContains(request.DataCancelamentoNotContains);
					else
						filter &= ContratoSpecifications.DataCancelamentoNotContains(request.DataCancelamentoNotContains);
				}
				if (request.DataCancelamentoSince.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataCancelamentoGreaterThanOrEqual(request.DataCancelamentoSince.Value);
					else
						filter &= ContratoSpecifications.DataCancelamentoGreaterThanOrEqual(request.DataCancelamentoSince.Value);
				}
				if (request.DataCancelamentoUntil.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataCancelamentoLessThan(request.DataCancelamentoUntil.Value);
					else
						filter &= ContratoSpecifications.DataCancelamentoLessThan(request.DataCancelamentoUntil.Value);
				}
				if (request.DataCancelamentoNotEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataCancelamentoNotEqual(request.DataCancelamentoNotEqual.Value);
					else
						filter &= ContratoSpecifications.DataCancelamentoNotEqual(request.DataCancelamentoNotEqual.Value);
				}
				if (request.DataCancelamentoLessThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataCancelamentoLessThan(request.DataCancelamentoLessThan.Value);
					else
						filter &= ContratoSpecifications.DataCancelamentoLessThan(request.DataCancelamentoLessThan.Value);
				}
				if (request.DataCancelamentoGreaterThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataCancelamentoGreaterThan(request.DataCancelamentoGreaterThan.Value);
					else
						filter &= ContratoSpecifications.DataCancelamentoGreaterThan(request.DataCancelamentoGreaterThan.Value);
				}
				if (request.DataCancelamentoLessThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataCancelamentoLessThanOrEqual(request.DataCancelamentoLessThanOrEqual.Value);
					else
						filter &= ContratoSpecifications.DataCancelamentoLessThanOrEqual(request.DataCancelamentoLessThanOrEqual.Value);
				}
				if (request.DataCancelamentoGreaterThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DataCancelamentoGreaterThanOrEqual(request.DataCancelamentoGreaterThanOrEqual.Value);
					else
						filter &= ContratoSpecifications.DataCancelamentoGreaterThanOrEqual(request.DataCancelamentoGreaterThanOrEqual.Value);
				}
				if (request.UserIdEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UserIdEqual(request.UserIdEqual.Value);
					else
						filter &= ContratoSpecifications.UserIdEqual(request.UserIdEqual.Value);
				}
				if (request.UserIdNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UserIdNotEqual(request.UserIdNotEqual.Value);
					else
						filter &= ContratoSpecifications.UserIdNotEqual(request.UserIdNotEqual.Value);
				}
				if (request.UserIdContains != null)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UserIdContains(request.UserIdContains);
					else
						filter &= ContratoSpecifications.UserIdContains(request.UserIdContains);
				}
				if (request.UserIdNotContains != null)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UserIdNotContains(request.UserIdNotContains);
					else
						filter &= ContratoSpecifications.UserIdNotContains(request.UserIdNotContains);
				}
				if (request.UserIdSince.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UserIdGreaterThanOrEqual(request.UserIdSince.Value);
					else
						filter &= ContratoSpecifications.UserIdGreaterThanOrEqual(request.UserIdSince.Value);
				}
				if (request.UserIdUntil.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UserIdLessThan(request.UserIdUntil.Value);
					else
						filter &= ContratoSpecifications.UserIdLessThan(request.UserIdUntil.Value);
				}
				if (request.UserIdNotEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UserIdNotEqual(request.UserIdNotEqual.Value);
					else
						filter &= ContratoSpecifications.UserIdNotEqual(request.UserIdNotEqual.Value);
				}
				if (request.UserIdLessThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UserIdLessThan(request.UserIdLessThan.Value);
					else
						filter &= ContratoSpecifications.UserIdLessThan(request.UserIdLessThan.Value);
				}
				if (request.UserIdGreaterThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UserIdGreaterThan(request.UserIdGreaterThan.Value);
					else
						filter &= ContratoSpecifications.UserIdGreaterThan(request.UserIdGreaterThan.Value);
				}
				if (request.UserIdLessThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UserIdLessThanOrEqual(request.UserIdLessThanOrEqual.Value);
					else
						filter &= ContratoSpecifications.UserIdLessThanOrEqual(request.UserIdLessThanOrEqual.Value);
				}
				if (request.UserIdGreaterThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UserIdGreaterThanOrEqual(request.UserIdGreaterThanOrEqual.Value);
					else
						filter &= ContratoSpecifications.UserIdGreaterThanOrEqual(request.UserIdGreaterThanOrEqual.Value);
				}
				if (!string.IsNullOrWhiteSpace(request.ExternalIdEqual)) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.ExternalIdEqual(request.ExternalIdEqual);
					else
						filter &= ContratoSpecifications.ExternalIdEqual(request.ExternalIdEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.ExternalIdNotEqual)) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.ExternalIdNotEqual(request.ExternalIdNotEqual);
					else
						filter &= ContratoSpecifications.ExternalIdNotEqual(request.ExternalIdNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.ExternalIdNotEqual)) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.ExternalIdNotEqual(request.ExternalIdNotEqual);
					else
						filter &= ContratoSpecifications.ExternalIdNotEqual(request.ExternalIdNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.ExternalIdContains)) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.ExternalIdContains(request.ExternalIdContains);
					else
						filter &= ContratoSpecifications.ExternalIdContains(request.ExternalIdContains);
				}
				if (!string.IsNullOrWhiteSpace(request.ExternalIdStartsWith)) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.ExternalIdStartsWith(request.ExternalIdStartsWith);
					else
						filter &= ContratoSpecifications.ExternalIdStartsWith(request.ExternalIdStartsWith);
				}
				if (request.CreatedAtEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.CreatedAtEqual(request.CreatedAtEqual.Value);
					else
						filter &= ContratoSpecifications.CreatedAtEqual(request.CreatedAtEqual.Value);
				}
				if (request.CreatedAtNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.CreatedAtNotEqual(request.CreatedAtNotEqual.Value);
					else
						filter &= ContratoSpecifications.CreatedAtNotEqual(request.CreatedAtNotEqual.Value);
				}
				if (request.CreatedAtContains != null)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.CreatedAtContains(request.CreatedAtContains);
					else
						filter &= ContratoSpecifications.CreatedAtContains(request.CreatedAtContains);
				}
				if (request.CreatedAtNotContains != null)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.CreatedAtNotContains(request.CreatedAtNotContains);
					else
						filter &= ContratoSpecifications.CreatedAtNotContains(request.CreatedAtNotContains);
				}
				if (request.CreatedAtSince.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.CreatedAtGreaterThanOrEqual(request.CreatedAtSince.Value);
					else
						filter &= ContratoSpecifications.CreatedAtGreaterThanOrEqual(request.CreatedAtSince.Value);
				}
				if (request.CreatedAtUntil.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.CreatedAtLessThan(request.CreatedAtUntil.Value);
					else
						filter &= ContratoSpecifications.CreatedAtLessThan(request.CreatedAtUntil.Value);
				}
				if (request.CreatedAtNotEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.CreatedAtNotEqual(request.CreatedAtNotEqual.Value);
					else
						filter &= ContratoSpecifications.CreatedAtNotEqual(request.CreatedAtNotEqual.Value);
				}
				if (request.CreatedAtLessThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.CreatedAtLessThan(request.CreatedAtLessThan.Value);
					else
						filter &= ContratoSpecifications.CreatedAtLessThan(request.CreatedAtLessThan.Value);
				}
				if (request.CreatedAtGreaterThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.CreatedAtGreaterThan(request.CreatedAtGreaterThan.Value);
					else
						filter &= ContratoSpecifications.CreatedAtGreaterThan(request.CreatedAtGreaterThan.Value);
				}
				if (request.CreatedAtLessThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.CreatedAtLessThanOrEqual(request.CreatedAtLessThanOrEqual.Value);
					else
						filter &= ContratoSpecifications.CreatedAtLessThanOrEqual(request.CreatedAtLessThanOrEqual.Value);
				}
				if (request.CreatedAtGreaterThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.CreatedAtGreaterThanOrEqual(request.CreatedAtGreaterThanOrEqual.Value);
					else
						filter &= ContratoSpecifications.CreatedAtGreaterThanOrEqual(request.CreatedAtGreaterThanOrEqual.Value);
				}
				if (request.UpdatedAtEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UpdatedAtEqual(request.UpdatedAtEqual.Value);
					else
						filter &= ContratoSpecifications.UpdatedAtEqual(request.UpdatedAtEqual.Value);
				}
				if (request.UpdatedAtNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UpdatedAtNotEqual(request.UpdatedAtNotEqual.Value);
					else
						filter &= ContratoSpecifications.UpdatedAtNotEqual(request.UpdatedAtNotEqual.Value);
				}
				if (request.UpdatedAtContains != null)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UpdatedAtContains(request.UpdatedAtContains);
					else
						filter &= ContratoSpecifications.UpdatedAtContains(request.UpdatedAtContains);
				}
				if (request.UpdatedAtNotContains != null)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UpdatedAtNotContains(request.UpdatedAtNotContains);
					else
						filter &= ContratoSpecifications.UpdatedAtNotContains(request.UpdatedAtNotContains);
				}
				if (request.UpdatedAtSince.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UpdatedAtGreaterThanOrEqual(request.UpdatedAtSince.Value);
					else
						filter &= ContratoSpecifications.UpdatedAtGreaterThanOrEqual(request.UpdatedAtSince.Value);
				}
				if (request.UpdatedAtUntil.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UpdatedAtLessThan(request.UpdatedAtUntil.Value);
					else
						filter &= ContratoSpecifications.UpdatedAtLessThan(request.UpdatedAtUntil.Value);
				}
				if (request.UpdatedAtNotEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UpdatedAtNotEqual(request.UpdatedAtNotEqual.Value);
					else
						filter &= ContratoSpecifications.UpdatedAtNotEqual(request.UpdatedAtNotEqual.Value);
				}
				if (request.UpdatedAtLessThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UpdatedAtLessThan(request.UpdatedAtLessThan.Value);
					else
						filter &= ContratoSpecifications.UpdatedAtLessThan(request.UpdatedAtLessThan.Value);
				}
				if (request.UpdatedAtGreaterThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UpdatedAtGreaterThan(request.UpdatedAtGreaterThan.Value);
					else
						filter &= ContratoSpecifications.UpdatedAtGreaterThan(request.UpdatedAtGreaterThan.Value);
				}
				if (request.UpdatedAtLessThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UpdatedAtLessThanOrEqual(request.UpdatedAtLessThanOrEqual.Value);
					else
						filter &= ContratoSpecifications.UpdatedAtLessThanOrEqual(request.UpdatedAtLessThanOrEqual.Value);
				}
				if (request.UpdatedAtGreaterThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.UpdatedAtGreaterThanOrEqual(request.UpdatedAtGreaterThanOrEqual.Value);
					else
						filter &= ContratoSpecifications.UpdatedAtGreaterThanOrEqual(request.UpdatedAtGreaterThanOrEqual.Value);
				}
				if (request.DeletedAtEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DeletedAtEqual(request.DeletedAtEqual.Value);
					else
						filter &= ContratoSpecifications.DeletedAtEqual(request.DeletedAtEqual.Value);
				}
				if (request.DeletedAtNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DeletedAtNotEqual(request.DeletedAtNotEqual.Value);
					else
						filter &= ContratoSpecifications.DeletedAtNotEqual(request.DeletedAtNotEqual.Value);
				}
				if (request.DeletedAtContains != null)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DeletedAtContains(request.DeletedAtContains);
					else
						filter &= ContratoSpecifications.DeletedAtContains(request.DeletedAtContains);
				}
				if (request.DeletedAtNotContains != null)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DeletedAtNotContains(request.DeletedAtNotContains);
					else
						filter &= ContratoSpecifications.DeletedAtNotContains(request.DeletedAtNotContains);
				}
				if (request.DeletedAtSince.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DeletedAtGreaterThanOrEqual(request.DeletedAtSince.Value);
					else
						filter &= ContratoSpecifications.DeletedAtGreaterThanOrEqual(request.DeletedAtSince.Value);
				}
				if (request.DeletedAtUntil.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DeletedAtLessThan(request.DeletedAtUntil.Value);
					else
						filter &= ContratoSpecifications.DeletedAtLessThan(request.DeletedAtUntil.Value);
				}
				if (request.DeletedAtNotEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DeletedAtNotEqual(request.DeletedAtNotEqual.Value);
					else
						filter &= ContratoSpecifications.DeletedAtNotEqual(request.DeletedAtNotEqual.Value);
				}
				if (request.DeletedAtLessThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DeletedAtLessThan(request.DeletedAtLessThan.Value);
					else
						filter &= ContratoSpecifications.DeletedAtLessThan(request.DeletedAtLessThan.Value);
				}
				if (request.DeletedAtGreaterThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DeletedAtGreaterThan(request.DeletedAtGreaterThan.Value);
					else
						filter &= ContratoSpecifications.DeletedAtGreaterThan(request.DeletedAtGreaterThan.Value);
				}
				if (request.DeletedAtLessThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DeletedAtLessThanOrEqual(request.DeletedAtLessThanOrEqual.Value);
					else
						filter &= ContratoSpecifications.DeletedAtLessThanOrEqual(request.DeletedAtLessThanOrEqual.Value);
				}
				if (request.DeletedAtGreaterThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DeletedAtGreaterThanOrEqual(request.DeletedAtGreaterThanOrEqual.Value);
					else
						filter &= ContratoSpecifications.DeletedAtGreaterThanOrEqual(request.DeletedAtGreaterThanOrEqual.Value);
				}
				if (request.IdEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.IdEqual(request.IdEqual.Value);
					else
						filter &= ContratoSpecifications.IdEqual(request.IdEqual.Value);
				}
				if (request.IdNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.IdNotEqual(request.IdNotEqual.Value);
					else
						filter &= ContratoSpecifications.IdNotEqual(request.IdNotEqual.Value);
				}
				if (request.IdContains != null)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.IdContains(request.IdContains);
					else
						filter &= ContratoSpecifications.IdContains(request.IdContains);
				}
				if (request.IdNotContains != null)
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.IdNotContains(request.IdNotContains);
					else
						filter &= ContratoSpecifications.IdNotContains(request.IdNotContains);
				}
				if (request.DeletadoEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= ContratoSpecifications.DeletadoEqual(request.DeletadoEqual.Value);
					else
						filter &= ContratoSpecifications.DeletadoEqual(request.DeletadoEqual.Value);
				}
			}
			return filter;
		}
	}
