namespace Bmg.Desafio.Users.Domain.Aggregates.UsersAgg.Specifications;
using Entities;
using Microsoft.EntityFrameworkCore;
using Core.Domain.Seedwork.Specification;
public partial class UserSpecifications {
				public static Specification<User> NameContains(string value) {
			return new DirectSpecification<User>(p => EF.Functions.Like(p.Name.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<User> NameNotContains(string value) {
			return new DirectSpecification<User>(p => !EF.Functions.Like(p.Name.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<User> NameStartsWith(string value) {
			return new DirectSpecification<User>(p => EF.Functions.Like(p.Name.ToLower(), $"{value.ToLower()}%"));
		}
	
		public static Specification<User> NameEqual(string value) {
			return new DirectSpecification<User>(p => value.ToLower() == (p.Name.ToLower()));
		}
		public static Specification<User> NameNotEqual(string value) {
			return new DirectSpecification<User>(p => p.Name != value);
		}
		public static Specification<User> NameIsNull() {
            return new DirectSpecification<User>(p => p.Name == null);
        }
		public static Specification<User> NameIsNotNull() {
            return new DirectSpecification<User>(p => p.Name != null);
        }
		
					public static Specification<User> UserRoleEqual(params Bmg.Desafio.Users.Enumerations.UserRole[] values) {
			return new DirectSpecification<User>(p => values.Contains(p.UserRole));
		}
		public static Specification<User> UserRoleNotEqual(Bmg.Desafio.Users.Enumerations.UserRole value) {
			return new DirectSpecification<User>(p => p.UserRole != value);
		}
	
					public static Specification<User> NeedSendOnboardingMailEqual(bool value) {
			return new DirectSpecification<User>(p => p.NeedSendOnboardingMail == value);
		}
		
					public static Specification<User> DocumentContains(string value) {
			return new DirectSpecification<User>(p => EF.Functions.Like(p.Document.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<User> DocumentNotContains(string value) {
			return new DirectSpecification<User>(p => !EF.Functions.Like(p.Document.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<User> DocumentStartsWith(string value) {
			return new DirectSpecification<User>(p => EF.Functions.Like(p.Document.ToLower(), $"{value.ToLower()}%"));
		}
	
		public static Specification<User> DocumentEqual(string value) {
			return new DirectSpecification<User>(p => value.ToLower() == (p.Document.ToLower()));
		}
		public static Specification<User> DocumentNotEqual(string value) {
			return new DirectSpecification<User>(p => p.Document != value);
		}
		public static Specification<User> DocumentIsNull() {
            return new DirectSpecification<User>(p => p.Document == null);
        }
		public static Specification<User> DocumentIsNotNull() {
            return new DirectSpecification<User>(p => p.Document != null);
        }
		
					public static Specification<User> EmailContains(string value) {
			return new DirectSpecification<User>(p => EF.Functions.Like(p.Email.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<User> EmailNotContains(string value) {
			return new DirectSpecification<User>(p => !EF.Functions.Like(p.Email.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<User> EmailStartsWith(string value) {
			return new DirectSpecification<User>(p => EF.Functions.Like(p.Email.ToLower(), $"{value.ToLower()}%"));
		}
	
		public static Specification<User> EmailEqual(string value) {
			return new DirectSpecification<User>(p => value.ToLower() == (p.Email.ToLower()));
		}
		public static Specification<User> EmailNotEqual(string value) {
			return new DirectSpecification<User>(p => p.Email != value);
		}
		public static Specification<User> EmailIsNull() {
            return new DirectSpecification<User>(p => p.Email == null);
        }
		public static Specification<User> EmailIsNotNull() {
            return new DirectSpecification<User>(p => p.Email != null);
        }
		
					public static Specification<User> PhoneNumberContains(string value) {
			return new DirectSpecification<User>(p => EF.Functions.Like(p.PhoneNumber.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<User> PhoneNumberNotContains(string value) {
			return new DirectSpecification<User>(p => !EF.Functions.Like(p.PhoneNumber.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<User> PhoneNumberStartsWith(string value) {
			return new DirectSpecification<User>(p => EF.Functions.Like(p.PhoneNumber.ToLower(), $"{value.ToLower()}%"));
		}
	
		public static Specification<User> PhoneNumberEqual(string value) {
			return new DirectSpecification<User>(p => value.ToLower() == (p.PhoneNumber.ToLower()));
		}
		public static Specification<User> PhoneNumberNotEqual(string value) {
			return new DirectSpecification<User>(p => p.PhoneNumber != value);
		}
		public static Specification<User> PhoneNumberIsNull() {
            return new DirectSpecification<User>(p => p.PhoneNumber == null);
        }
		public static Specification<User> PhoneNumberIsNotNull() {
            return new DirectSpecification<User>(p => p.PhoneNumber != null);
        }
		
					public static Specification<User> UserNameContains(string value) {
			return new DirectSpecification<User>(p => EF.Functions.Like(p.UserName.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<User> UserNameNotContains(string value) {
			return new DirectSpecification<User>(p => !EF.Functions.Like(p.UserName.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<User> UserNameStartsWith(string value) {
			return new DirectSpecification<User>(p => EF.Functions.Like(p.UserName.ToLower(), $"{value.ToLower()}%"));
		}
	
		public static Specification<User> UserNameEqual(string value) {
			return new DirectSpecification<User>(p => value.ToLower() == (p.UserName.ToLower()));
		}
		public static Specification<User> UserNameNotEqual(string value) {
			return new DirectSpecification<User>(p => p.UserName != value);
		}
		public static Specification<User> UserNameIsNull() {
            return new DirectSpecification<User>(p => p.UserName == null);
        }
		public static Specification<User> UserNameIsNotNull() {
            return new DirectSpecification<User>(p => p.UserName != null);
        }
		
					public static Specification<User> PasswordContains(string value) {
			return new DirectSpecification<User>(p => EF.Functions.Like(p.Password.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<User> PasswordNotContains(string value) {
			return new DirectSpecification<User>(p => !EF.Functions.Like(p.Password.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<User> PasswordStartsWith(string value) {
			return new DirectSpecification<User>(p => EF.Functions.Like(p.Password.ToLower(), $"{value.ToLower()}%"));
		}
	
		public static Specification<User> PasswordEqual(string value) {
			return new DirectSpecification<User>(p => value.ToLower() == (p.Password.ToLower()));
		}
		public static Specification<User> PasswordNotEqual(string value) {
			return new DirectSpecification<User>(p => p.Password != value);
		}
		public static Specification<User> PasswordIsNull() {
            return new DirectSpecification<User>(p => p.Password == null);
        }
		public static Specification<User> PasswordIsNotNull() {
            return new DirectSpecification<User>(p => p.Password != null);
        }
		
					public static Specification<User> AuthTokenContains(string value) {
			return new DirectSpecification<User>(p => EF.Functions.Like(p.AuthToken.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<User> AuthTokenNotContains(string value) {
			return new DirectSpecification<User>(p => !EF.Functions.Like(p.AuthToken.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<User> AuthTokenStartsWith(string value) {
			return new DirectSpecification<User>(p => EF.Functions.Like(p.AuthToken.ToLower(), $"{value.ToLower()}%"));
		}
	
		public static Specification<User> AuthTokenEqual(string value) {
			return new DirectSpecification<User>(p => value.ToLower() == (p.AuthToken.ToLower()));
		}
		public static Specification<User> AuthTokenNotEqual(string value) {
			return new DirectSpecification<User>(p => p.AuthToken != value);
		}
		public static Specification<User> AuthTokenIsNull() {
            return new DirectSpecification<User>(p => p.AuthToken == null);
        }
		public static Specification<User> AuthTokenIsNotNull() {
            return new DirectSpecification<User>(p => p.AuthToken != null);
        }
		
					public static Specification<User> ExternalIdContains(string value) {
			return new DirectSpecification<User>(p => EF.Functions.Like(p.ExternalId.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<User> ExternalIdNotContains(string value) {
			return new DirectSpecification<User>(p => !EF.Functions.Like(p.ExternalId.ToLower(), $"%{value.ToLower()}%"));
		}
		public static Specification<User> ExternalIdStartsWith(string value) {
			return new DirectSpecification<User>(p => EF.Functions.Like(p.ExternalId.ToLower(), $"{value.ToLower()}%"));
		}
	
		public static Specification<User> ExternalIdEqual(string value) {
			return new DirectSpecification<User>(p => value.ToLower() == (p.ExternalId.ToLower()));
		}
		public static Specification<User> ExternalIdNotEqual(string value) {
			return new DirectSpecification<User>(p => p.ExternalId != value);
		}
		public static Specification<User> ExternalIdIsNull() {
            return new DirectSpecification<User>(p => p.ExternalId == null);
        }
		public static Specification<User> ExternalIdIsNotNull() {
            return new DirectSpecification<User>(p => p.ExternalId != null);
        }
		
					public static Specification<User> CreatedAtContains(params System.DateTime[] values) {
            return new DirectSpecification<User>(p => values.Contains(p.CreatedAt.Value));
        }
		public static Specification<User> CreatedAtNotContains(params System.DateTime[] values) {
            return new DirectSpecification<User>(p => !values.Contains(p.CreatedAt.Value));
        }
		public static Specification<User> CreatedAtEqual(params System.DateTime[] values) {
			return new DirectSpecification<User>(p => values.Contains(p.CreatedAt.Value));
        }
        public static Specification<User> CreatedAtGreaterThanOrEqual(System.DateTime value) {
            return new DirectSpecification<User>(p => p.CreatedAt >= value);
        }
        public static Specification<User> CreatedAtLessThanOrEqual(System.DateTime value) {
            return new DirectSpecification<User>(p => p.CreatedAt <= value);
        }
        public static Specification<User> CreatedAtNotEqual(System.DateTime value) {
            return new DirectSpecification<User>(p => p.CreatedAt != value);
        }
        public static Specification<User> CreatedAtGreaterThan(System.DateTime value) {
            return new DirectSpecification<User>(p => p.CreatedAt > value);
        }
        public static Specification<User> CreatedAtLessThan(System.DateTime value) {
            return new DirectSpecification<User>(p => p.CreatedAt < value);
        }
		
					public static Specification<User> UpdatedAtContains(params System.DateTime[] values) {
            return new DirectSpecification<User>(p => values.Contains(p.UpdatedAt.Value));
        }
		public static Specification<User> UpdatedAtNotContains(params System.DateTime[] values) {
            return new DirectSpecification<User>(p => !values.Contains(p.UpdatedAt.Value));
        }
		public static Specification<User> UpdatedAtEqual(params System.DateTime[] values) {
			return new DirectSpecification<User>(p => values.Contains(p.UpdatedAt.Value));
        }
        public static Specification<User> UpdatedAtGreaterThanOrEqual(System.DateTime value) {
            return new DirectSpecification<User>(p => p.UpdatedAt >= value);
        }
        public static Specification<User> UpdatedAtLessThanOrEqual(System.DateTime value) {
            return new DirectSpecification<User>(p => p.UpdatedAt <= value);
        }
        public static Specification<User> UpdatedAtNotEqual(System.DateTime value) {
            return new DirectSpecification<User>(p => p.UpdatedAt != value);
        }
        public static Specification<User> UpdatedAtGreaterThan(System.DateTime value) {
            return new DirectSpecification<User>(p => p.UpdatedAt > value);
        }
        public static Specification<User> UpdatedAtLessThan(System.DateTime value) {
            return new DirectSpecification<User>(p => p.UpdatedAt < value);
        }
		
					public static Specification<User> DeletedAtContains(params System.DateTime[] values) {
            return new DirectSpecification<User>(p => values.Contains(p.DeletedAt.Value));
        }
		public static Specification<User> DeletedAtNotContains(params System.DateTime[] values) {
            return new DirectSpecification<User>(p => !values.Contains(p.DeletedAt.Value));
        }
		public static Specification<User> DeletedAtEqual(params System.DateTime[] values) {
			return new DirectSpecification<User>(p => values.Contains(p.DeletedAt.Value));
        }
        public static Specification<User> DeletedAtGreaterThanOrEqual(System.DateTime value) {
            return new DirectSpecification<User>(p => p.DeletedAt >= value);
        }
        public static Specification<User> DeletedAtLessThanOrEqual(System.DateTime value) {
            return new DirectSpecification<User>(p => p.DeletedAt <= value);
        }
        public static Specification<User> DeletedAtNotEqual(System.DateTime value) {
            return new DirectSpecification<User>(p => p.DeletedAt != value);
        }
        public static Specification<User> DeletedAtGreaterThan(System.DateTime value) {
            return new DirectSpecification<User>(p => p.DeletedAt > value);
        }
        public static Specification<User> DeletedAtLessThan(System.DateTime value) {
            return new DirectSpecification<User>(p => p.DeletedAt < value);
        }
		
					public static Specification<User> IdContains(params int[] values) {
            return new DirectSpecification<User>(p => values.Contains(p.Id));
        }
		public static Specification<User> IdNotContains(params int[] values) {
            return new DirectSpecification<User>(p => !values.Contains(p.Id));
        }
		public static Specification<User> IdEqual(params int[] values) {
			return new DirectSpecification<User>(p => values.Contains(p.Id));
        }
        public static Specification<User> IdGreaterThanOrEqual(int value) {
            return new DirectSpecification<User>(p => p.Id >= value);
        }
        public static Specification<User> IdLessThanOrEqual(int value) {
            return new DirectSpecification<User>(p => p.Id <= value);
        }
        public static Specification<User> IdNotEqual(int value) {
            return new DirectSpecification<User>(p => p.Id != value);
        }
        public static Specification<User> IdGreaterThan(int value) {
            return new DirectSpecification<User>(p => p.Id > value);
        }
        public static Specification<User> IdLessThan(int value) {
            return new DirectSpecification<User>(p => p.Id < value);
        }
		
					public static Specification<User> DeletadoEqual(bool value) {
			return new DirectSpecification<User>(p => p.Deletado == value);
		}
		
	   }
