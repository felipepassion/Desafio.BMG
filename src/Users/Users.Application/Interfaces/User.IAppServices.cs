
using System.Linq.Expressions;

namespace Bmg.Desafio.Users.Application.Aggregates.UsersAgg.AppServices;
	using Application.DTO.Aggregates.UsersAgg.Requests;
    using Domain.Aggregates.UsersAgg.Queries.Models;
	using Core.Application.Aggregates.Common;
	using Core.Application.DTO.Http.Models.Responses;

	public partial interface IUserAppService : IBaseAppService {	
		public Task<UserDTO> Get(UserQueryModel request);
		public Task<int> CountAsync(UserQueryModel request);
		public Task<IEnumerable<UserDTO>> GetAll(UserQueryModel request, int? page = null, int? size = null);
		public Task<T> Select<T>(UserQueryModel request, Expression<Func<Domain.Aggregates.UsersAgg.Entities.User, T>> selector = null);
		public Task<IEnumerable<T>> GetAll<T>(UserQueryModel request, int? page = null, int? size = null, Expression<Func<Domain.Aggregates.UsersAgg.Entities.User, T>> selector = null);

		public Task<DomainResponse> Create(UserDTO request, bool updateIfExists = true, UserQueryModel searchQuery = null);
		public Task<DomainResponse> Delete(UserQueryModel request);
		public Task<DomainResponse> DeleteRange(UserQueryModel request);
		public Task Update(UserQueryModel searchQuery, UserDTO request, bool createIfNotExists = true);
}
	