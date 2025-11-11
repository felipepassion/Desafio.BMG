
namespace Bmg.Desafio.Users.Domain.Aggregates.UsersAgg.Filters;

using Bmg.Desafio.CrossCuting.Infra.Utils.Extensions;
using System.Linq.Expressions;
using Bmg.Desafio.Core.Domain.Seedwork.Specification;
using Entities;
using Specifications;
using Queries.Models;

	public static class UserFilters 
	{
	    public static Expression<Func<User, bool>> GetFilters(this UserQueryModel request, bool isOrSpecification = false)

		{ return request.GetFiltersSpecification(isOrSpecification).SatisfiedBy(); }
		public static Specification<User> GetFiltersSpecification(this UserQueryModel request, bool isOrSpecification = false) 
		{
			isOrSpecification = request.IsOrSpecification;
			Specification<User> filter = new DirectSpecification<User>(p => request.IsEmpty() || !isOrSpecification);
			if(request is not null)
			{
				if (!string.IsNullOrWhiteSpace(request.NameEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.NameEqual(request.NameEqual);
					else
						filter &= UserSpecifications.NameEqual(request.NameEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.NameNotEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.NameNotEqual(request.NameNotEqual);
					else
						filter &= UserSpecifications.NameNotEqual(request.NameNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.NameNotEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.NameNotEqual(request.NameNotEqual);
					else
						filter &= UserSpecifications.NameNotEqual(request.NameNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.NameContains)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.NameContains(request.NameContains);
					else
						filter &= UserSpecifications.NameContains(request.NameContains);
				}
				if (!string.IsNullOrWhiteSpace(request.NameStartsWith)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.NameStartsWith(request.NameStartsWith);
					else
						filter &= UserSpecifications.NameStartsWith(request.NameStartsWith);
				}
				if (request.UserRoleEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.UserRoleEqual(request.UserRoleEqual.Value);
					else
						filter &= UserSpecifications.UserRoleEqual(request.UserRoleEqual.Value);
				}
				if (request.NeedSendOnboardingMailEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.NeedSendOnboardingMailEqual(request.NeedSendOnboardingMailEqual.Value);
					else
						filter &= UserSpecifications.NeedSendOnboardingMailEqual(request.NeedSendOnboardingMailEqual.Value);
				}
				if (!string.IsNullOrWhiteSpace(request.DocumentEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.DocumentEqual(request.DocumentEqual);
					else
						filter &= UserSpecifications.DocumentEqual(request.DocumentEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.DocumentNotEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.DocumentNotEqual(request.DocumentNotEqual);
					else
						filter &= UserSpecifications.DocumentNotEqual(request.DocumentNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.DocumentNotEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.DocumentNotEqual(request.DocumentNotEqual);
					else
						filter &= UserSpecifications.DocumentNotEqual(request.DocumentNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.DocumentContains)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.DocumentContains(request.DocumentContains);
					else
						filter &= UserSpecifications.DocumentContains(request.DocumentContains);
				}
				if (!string.IsNullOrWhiteSpace(request.DocumentStartsWith)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.DocumentStartsWith(request.DocumentStartsWith);
					else
						filter &= UserSpecifications.DocumentStartsWith(request.DocumentStartsWith);
				}
				if (!string.IsNullOrWhiteSpace(request.EmailEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.EmailEqual(request.EmailEqual);
					else
						filter &= UserSpecifications.EmailEqual(request.EmailEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.EmailNotEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.EmailNotEqual(request.EmailNotEqual);
					else
						filter &= UserSpecifications.EmailNotEqual(request.EmailNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.EmailNotEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.EmailNotEqual(request.EmailNotEqual);
					else
						filter &= UserSpecifications.EmailNotEqual(request.EmailNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.EmailContains)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.EmailContains(request.EmailContains);
					else
						filter &= UserSpecifications.EmailContains(request.EmailContains);
				}
				if (!string.IsNullOrWhiteSpace(request.EmailStartsWith)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.EmailStartsWith(request.EmailStartsWith);
					else
						filter &= UserSpecifications.EmailStartsWith(request.EmailStartsWith);
				}
				if (!string.IsNullOrWhiteSpace(request.PhoneNumberEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.PhoneNumberEqual(request.PhoneNumberEqual);
					else
						filter &= UserSpecifications.PhoneNumberEqual(request.PhoneNumberEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.PhoneNumberNotEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.PhoneNumberNotEqual(request.PhoneNumberNotEqual);
					else
						filter &= UserSpecifications.PhoneNumberNotEqual(request.PhoneNumberNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.PhoneNumberNotEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.PhoneNumberNotEqual(request.PhoneNumberNotEqual);
					else
						filter &= UserSpecifications.PhoneNumberNotEqual(request.PhoneNumberNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.PhoneNumberContains)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.PhoneNumberContains(request.PhoneNumberContains);
					else
						filter &= UserSpecifications.PhoneNumberContains(request.PhoneNumberContains);
				}
				if (!string.IsNullOrWhiteSpace(request.PhoneNumberStartsWith)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.PhoneNumberStartsWith(request.PhoneNumberStartsWith);
					else
						filter &= UserSpecifications.PhoneNumberStartsWith(request.PhoneNumberStartsWith);
				}
				if (!string.IsNullOrWhiteSpace(request.UserNameEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.UserNameEqual(request.UserNameEqual);
					else
						filter &= UserSpecifications.UserNameEqual(request.UserNameEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.UserNameNotEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.UserNameNotEqual(request.UserNameNotEqual);
					else
						filter &= UserSpecifications.UserNameNotEqual(request.UserNameNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.UserNameNotEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.UserNameNotEqual(request.UserNameNotEqual);
					else
						filter &= UserSpecifications.UserNameNotEqual(request.UserNameNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.UserNameContains)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.UserNameContains(request.UserNameContains);
					else
						filter &= UserSpecifications.UserNameContains(request.UserNameContains);
				}
				if (!string.IsNullOrWhiteSpace(request.UserNameStartsWith)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.UserNameStartsWith(request.UserNameStartsWith);
					else
						filter &= UserSpecifications.UserNameStartsWith(request.UserNameStartsWith);
				}
				if (!string.IsNullOrWhiteSpace(request.PasswordEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.PasswordEqual(request.PasswordEqual);
					else
						filter &= UserSpecifications.PasswordEqual(request.PasswordEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.PasswordNotEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.PasswordNotEqual(request.PasswordNotEqual);
					else
						filter &= UserSpecifications.PasswordNotEqual(request.PasswordNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.PasswordNotEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.PasswordNotEqual(request.PasswordNotEqual);
					else
						filter &= UserSpecifications.PasswordNotEqual(request.PasswordNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.PasswordContains)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.PasswordContains(request.PasswordContains);
					else
						filter &= UserSpecifications.PasswordContains(request.PasswordContains);
				}
				if (!string.IsNullOrWhiteSpace(request.PasswordStartsWith)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.PasswordStartsWith(request.PasswordStartsWith);
					else
						filter &= UserSpecifications.PasswordStartsWith(request.PasswordStartsWith);
				}
				if (!string.IsNullOrWhiteSpace(request.AuthTokenEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.AuthTokenEqual(request.AuthTokenEqual);
					else
						filter &= UserSpecifications.AuthTokenEqual(request.AuthTokenEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.AuthTokenNotEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.AuthTokenNotEqual(request.AuthTokenNotEqual);
					else
						filter &= UserSpecifications.AuthTokenNotEqual(request.AuthTokenNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.AuthTokenNotEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.AuthTokenNotEqual(request.AuthTokenNotEqual);
					else
						filter &= UserSpecifications.AuthTokenNotEqual(request.AuthTokenNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.AuthTokenContains)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.AuthTokenContains(request.AuthTokenContains);
					else
						filter &= UserSpecifications.AuthTokenContains(request.AuthTokenContains);
				}
				if (!string.IsNullOrWhiteSpace(request.AuthTokenStartsWith)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.AuthTokenStartsWith(request.AuthTokenStartsWith);
					else
						filter &= UserSpecifications.AuthTokenStartsWith(request.AuthTokenStartsWith);
				}
				if (!string.IsNullOrWhiteSpace(request.ExternalIdEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.ExternalIdEqual(request.ExternalIdEqual);
					else
						filter &= UserSpecifications.ExternalIdEqual(request.ExternalIdEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.ExternalIdNotEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.ExternalIdNotEqual(request.ExternalIdNotEqual);
					else
						filter &= UserSpecifications.ExternalIdNotEqual(request.ExternalIdNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.ExternalIdNotEqual)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.ExternalIdNotEqual(request.ExternalIdNotEqual);
					else
						filter &= UserSpecifications.ExternalIdNotEqual(request.ExternalIdNotEqual);
				}
				if (!string.IsNullOrWhiteSpace(request.ExternalIdContains)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.ExternalIdContains(request.ExternalIdContains);
					else
						filter &= UserSpecifications.ExternalIdContains(request.ExternalIdContains);
				}
				if (!string.IsNullOrWhiteSpace(request.ExternalIdStartsWith)) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.ExternalIdStartsWith(request.ExternalIdStartsWith);
					else
						filter &= UserSpecifications.ExternalIdStartsWith(request.ExternalIdStartsWith);
				}
				if (request.CreatedAtEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.CreatedAtEqual(request.CreatedAtEqual.Value);
					else
						filter &= UserSpecifications.CreatedAtEqual(request.CreatedAtEqual.Value);
				}
				if (request.CreatedAtNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.CreatedAtNotEqual(request.CreatedAtNotEqual.Value);
					else
						filter &= UserSpecifications.CreatedAtNotEqual(request.CreatedAtNotEqual.Value);
				}
				if (request.CreatedAtContains != null)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.CreatedAtContains(request.CreatedAtContains);
					else
						filter &= UserSpecifications.CreatedAtContains(request.CreatedAtContains);
				}
				if (request.CreatedAtNotContains != null)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.CreatedAtNotContains(request.CreatedAtNotContains);
					else
						filter &= UserSpecifications.CreatedAtNotContains(request.CreatedAtNotContains);
				}
				if (request.CreatedAtSince.HasValue)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.CreatedAtGreaterThanOrEqual(request.CreatedAtSince.Value);
					else
						filter &= UserSpecifications.CreatedAtGreaterThanOrEqual(request.CreatedAtSince.Value);
				}
				if (request.CreatedAtUntil.HasValue)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.CreatedAtLessThan(request.CreatedAtUntil.Value);
					else
						filter &= UserSpecifications.CreatedAtLessThan(request.CreatedAtUntil.Value);
				}
				if (request.CreatedAtNotEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.CreatedAtNotEqual(request.CreatedAtNotEqual.Value);
					else
						filter &= UserSpecifications.CreatedAtNotEqual(request.CreatedAtNotEqual.Value);
				}
				if (request.CreatedAtLessThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.CreatedAtLessThan(request.CreatedAtLessThan.Value);
					else
						filter &= UserSpecifications.CreatedAtLessThan(request.CreatedAtLessThan.Value);
				}
				if (request.CreatedAtGreaterThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.CreatedAtGreaterThan(request.CreatedAtGreaterThan.Value);
					else
						filter &= UserSpecifications.CreatedAtGreaterThan(request.CreatedAtGreaterThan.Value);
				}
				if (request.CreatedAtLessThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.CreatedAtLessThanOrEqual(request.CreatedAtLessThanOrEqual.Value);
					else
						filter &= UserSpecifications.CreatedAtLessThanOrEqual(request.CreatedAtLessThanOrEqual.Value);
				}
				if (request.CreatedAtGreaterThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.CreatedAtGreaterThanOrEqual(request.CreatedAtGreaterThanOrEqual.Value);
					else
						filter &= UserSpecifications.CreatedAtGreaterThanOrEqual(request.CreatedAtGreaterThanOrEqual.Value);
				}
				if (request.UpdatedAtEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.UpdatedAtEqual(request.UpdatedAtEqual.Value);
					else
						filter &= UserSpecifications.UpdatedAtEqual(request.UpdatedAtEqual.Value);
				}
				if (request.UpdatedAtNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.UpdatedAtNotEqual(request.UpdatedAtNotEqual.Value);
					else
						filter &= UserSpecifications.UpdatedAtNotEqual(request.UpdatedAtNotEqual.Value);
				}
				if (request.UpdatedAtContains != null)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.UpdatedAtContains(request.UpdatedAtContains);
					else
						filter &= UserSpecifications.UpdatedAtContains(request.UpdatedAtContains);
				}
				if (request.UpdatedAtNotContains != null)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.UpdatedAtNotContains(request.UpdatedAtNotContains);
					else
						filter &= UserSpecifications.UpdatedAtNotContains(request.UpdatedAtNotContains);
				}
				if (request.UpdatedAtSince.HasValue)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.UpdatedAtGreaterThanOrEqual(request.UpdatedAtSince.Value);
					else
						filter &= UserSpecifications.UpdatedAtGreaterThanOrEqual(request.UpdatedAtSince.Value);
				}
				if (request.UpdatedAtUntil.HasValue)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.UpdatedAtLessThan(request.UpdatedAtUntil.Value);
					else
						filter &= UserSpecifications.UpdatedAtLessThan(request.UpdatedAtUntil.Value);
				}
				if (request.UpdatedAtNotEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.UpdatedAtNotEqual(request.UpdatedAtNotEqual.Value);
					else
						filter &= UserSpecifications.UpdatedAtNotEqual(request.UpdatedAtNotEqual.Value);
				}
				if (request.UpdatedAtLessThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.UpdatedAtLessThan(request.UpdatedAtLessThan.Value);
					else
						filter &= UserSpecifications.UpdatedAtLessThan(request.UpdatedAtLessThan.Value);
				}
				if (request.UpdatedAtGreaterThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.UpdatedAtGreaterThan(request.UpdatedAtGreaterThan.Value);
					else
						filter &= UserSpecifications.UpdatedAtGreaterThan(request.UpdatedAtGreaterThan.Value);
				}
				if (request.UpdatedAtLessThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.UpdatedAtLessThanOrEqual(request.UpdatedAtLessThanOrEqual.Value);
					else
						filter &= UserSpecifications.UpdatedAtLessThanOrEqual(request.UpdatedAtLessThanOrEqual.Value);
				}
				if (request.UpdatedAtGreaterThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.UpdatedAtGreaterThanOrEqual(request.UpdatedAtGreaterThanOrEqual.Value);
					else
						filter &= UserSpecifications.UpdatedAtGreaterThanOrEqual(request.UpdatedAtGreaterThanOrEqual.Value);
				}
				if (request.DeletedAtEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.DeletedAtEqual(request.DeletedAtEqual.Value);
					else
						filter &= UserSpecifications.DeletedAtEqual(request.DeletedAtEqual.Value);
				}
				if (request.DeletedAtNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.DeletedAtNotEqual(request.DeletedAtNotEqual.Value);
					else
						filter &= UserSpecifications.DeletedAtNotEqual(request.DeletedAtNotEqual.Value);
				}
				if (request.DeletedAtContains != null)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.DeletedAtContains(request.DeletedAtContains);
					else
						filter &= UserSpecifications.DeletedAtContains(request.DeletedAtContains);
				}
				if (request.DeletedAtNotContains != null)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.DeletedAtNotContains(request.DeletedAtNotContains);
					else
						filter &= UserSpecifications.DeletedAtNotContains(request.DeletedAtNotContains);
				}
				if (request.DeletedAtSince.HasValue)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.DeletedAtGreaterThanOrEqual(request.DeletedAtSince.Value);
					else
						filter &= UserSpecifications.DeletedAtGreaterThanOrEqual(request.DeletedAtSince.Value);
				}
				if (request.DeletedAtUntil.HasValue)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.DeletedAtLessThan(request.DeletedAtUntil.Value);
					else
						filter &= UserSpecifications.DeletedAtLessThan(request.DeletedAtUntil.Value);
				}
				if (request.DeletedAtNotEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.DeletedAtNotEqual(request.DeletedAtNotEqual.Value);
					else
						filter &= UserSpecifications.DeletedAtNotEqual(request.DeletedAtNotEqual.Value);
				}
				if (request.DeletedAtLessThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.DeletedAtLessThan(request.DeletedAtLessThan.Value);
					else
						filter &= UserSpecifications.DeletedAtLessThan(request.DeletedAtLessThan.Value);
				}
				if (request.DeletedAtGreaterThan.HasValue) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.DeletedAtGreaterThan(request.DeletedAtGreaterThan.Value);
					else
						filter &= UserSpecifications.DeletedAtGreaterThan(request.DeletedAtGreaterThan.Value);
				}
				if (request.DeletedAtLessThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.DeletedAtLessThanOrEqual(request.DeletedAtLessThanOrEqual.Value);
					else
						filter &= UserSpecifications.DeletedAtLessThanOrEqual(request.DeletedAtLessThanOrEqual.Value);
				}
				if (request.DeletedAtGreaterThanOrEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.DeletedAtGreaterThanOrEqual(request.DeletedAtGreaterThanOrEqual.Value);
					else
						filter &= UserSpecifications.DeletedAtGreaterThanOrEqual(request.DeletedAtGreaterThanOrEqual.Value);
				}
				if (request.IdEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.IdEqual(request.IdEqual.Value);
					else
						filter &= UserSpecifications.IdEqual(request.IdEqual.Value);
				}
				if (request.IdNotEqual.HasValue)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.IdNotEqual(request.IdNotEqual.Value);
					else
						filter &= UserSpecifications.IdNotEqual(request.IdNotEqual.Value);
				}
				if (request.IdContains != null)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.IdContains(request.IdContains);
					else
						filter &= UserSpecifications.IdContains(request.IdContains);
				}
				if (request.IdNotContains != null)
				{
					if (isOrSpecification)
						filter |= UserSpecifications.IdNotContains(request.IdNotContains);
					else
						filter &= UserSpecifications.IdNotContains(request.IdNotContains);
				}
				if (request.DeletadoEqual.HasValue) 
				{
					if (isOrSpecification)
						filter |= UserSpecifications.DeletadoEqual(request.DeletadoEqual.Value);
					else
						filter &= UserSpecifications.DeletadoEqual(request.DeletadoEqual.Value);
				}
			}
			return filter;
		}
	}
