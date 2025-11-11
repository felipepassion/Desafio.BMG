


using MediatR;
using System.Linq.Expressions;

namespace Bmg.Desafio.Users.Application.Aggregates.UsersAgg.AppServices;
	using Core.Application.DTO.Http.Models.Responses;
	using CrossCuting.Infra.Utils.Extensions;
	using Application.DTO.Aggregates.UsersAgg.Requests;
	using Domain.Aggregates.UsersAgg.Queries.Models;
	using Domain.Aggregates.UsersAgg.Repositories;
	using Domain.Aggregates.UsersAgg.Filters;
	using Domain.Aggregates.UsersAgg.Entities;
	using Domain.Aggregates.UsersAgg.Commands;
	using Core.Application.DTO.Extensions;
	using Core.Application.Aggregates.Common;

	public partial class UserAppService : BaseAppService, IUserAppService {	
		public IUserRepository _userRepository;
		public UserAppService(IMediator mediator, Bmg.Desafio.CrossCutting.Infra.Log.Contexts.ILogRequestContext ctx, IUserRepository userRepository) : base(ctx, mediator) { _userRepository = userRepository; }	
		public async Task<UserDTO> Get(UserQueryModel request) {
            return (await _userRepository.FindAsync(filter: UserFilters.GetFilters(request, isOrSpecification: request.IsOrSpecification), selector: x => x.ProjectedAs<UserDTO>()));
        }
		public void Dispose()
        {
			_userRepository = null;
        }
		public async Task<IEnumerable<T>> GetAll<T>(UserQueryModel request, int? page = null, int? size = null, Expression<Func<User, T>> selector = null) {
			return await _userRepository.SelectAllAsync(
                filter: UserFilters.GetFilters(request, isOrSpecification: request.IsOrSpecification),
                take: size,
                skip: page * size,
				ascending: request.OrderByDesc != true,
                orderBy: request.OrderBy.GetPropertyListSelector<User>(),
                selector: selector);
		}
		public async Task<T> Select<T>(UserQueryModel request, Expression<Func<User, T>> selector = null)
        {
            return (await _userRepository.FindAsync(filter: UserFilters.GetFilters(request, isOrSpecification: true), selector: selector));
        }
        public async Task<IEnumerable<UserDTO>> GetAll(UserQueryModel request, int? page = null, int? size = null) {
            return await _userRepository.FindAllAsync(
                filter: UserFilters.GetFilters(request, isOrSpecification: true),
                take: size,
                skip: page * size,
				ascending: request.OrderByDesc != true,
                orderBy: request.OrderBy.GetPropertyListSelector<User>(),
                selector: x => x.ProjectedAs<UserDTO>());
        }

		public Task<DomainResponse> Create(UserDTO request, bool updateIfExists = true, UserQueryModel searchQuery = null) { return _mediator.Send(new CreateUserCommand(_logRequestContext, request)); }
		public async Task<int> CountAsync(UserQueryModel request) { return await _userRepository.CountAsync(filter: UserFilters.GetFilters(request, isOrSpecification: true)); }
		public Task Update(UserQueryModel searchQuery, UserDTO request, bool createIfNotExists = true) { return _mediator.Send(new UpdateUserCommand(_logRequestContext, searchQuery, request)); }
		public Task<DomainResponse> DeleteRange(UserQueryModel request){ return _mediator.Send(new DeleteRangeUserCommand(_logRequestContext, request)); }
		public Task<DomainResponse> Delete(UserQueryModel request){ return _mediator.Send(new DeleteUserCommand(_logRequestContext, request)); }
	}
