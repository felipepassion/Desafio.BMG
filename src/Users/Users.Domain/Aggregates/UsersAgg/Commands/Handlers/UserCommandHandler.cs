
using MediatR;
using Bmg.Desafio.Core.Application.DTO.Http.Models.Responses;
using Bmg.Desafio.Core.Application.DTO.Extensions;
using Bmg.Desafio.CrossCuting.Infra.Utils.Extensions;

namespace Bmg.Desafio.Users.Domain.Aggregates.UsersAgg.Commands.Handlers;
    using Filters;
    using Events;
    using Repositories;
    using Commands;
    using Entities;
    using Queries.Models;
    using Application.DTO.Aggregates.UsersAgg.Requests;

    public partial class UserCommandHandler : BaseUsersAggCommandHandler<User>,
        IRequestHandler<CreateUserCommand,DomainResponse>,
        IRequestHandler<DeleteUserCommand,DomainResponse>,
        IRequestHandler<UpdateUserCommand,DomainResponse>
    {
        IUserRepository _userRepository;

        public UserCommandHandler(IServiceProvider provider,IMediator mediator,IUserRepository userRepository ) : base(provider,mediator) { _userRepository = userRepository; }

        partial void OnCreate(User entity);
        partial void OnUpdate(User entity);

        public async Task<DomainResponse> Handle(CreateUserCommand command,CancellationToken cancellationToken) {

            User entity;
            if (command.Query != null || !string.IsNullOrWhiteSpace(command.Request.ExternalId))
            {
                var filter = UserFilters.GetFilters(command.Query ?? new UserQueryModel { ExternalIdEqual = command.Request.ExternalId });
                entity = await _userRepository.FindAsync(filter, includeAll: false);
                if (entity != null)
                {
                    if (command.UpdateIfExists)
                        return await Handle(new UpdateUserCommand(
                            command.Context,
                            new Queries.Models.UserQueryModel { ExternalIdEqual = command.Request.ExternalId },
                            command.Request),
                        cancellationToken);
                }
            }
            entity = command.Request.ProjectedAs<Entities.User>();
            entity.AddDomainEvent(new UserCreatedEvent(command.Context,entity));

            var creationResult = await OnCreateAsync(entity);
            if (!creationResult.Success) return creationResult;
			_userRepository.Add(entity);

            var result = await Commit(_userRepository.UnitOfWork, entity.ProjectedAs<UserDTO>());
            result.Data = entity.ProjectedAs<UserDTO>();
            return result;
        }

        public async Task<DomainResponse> Handle(DeleteUserCommand command,CancellationToken cancellationToken) {
            var filter = UserFilters.GetFilters(command.Query);
			var entity = await _userRepository.FindAsync(filter);

            if(entity is null) {
                return AddError($"Entity {nameof(User)} not found with the request.");
            }
            
            if (command.IsLogicalDeletion)
                entity.Delete();
            else
			    _userRepository.Delete(entity);

            var deleteResult = await OnDeleteAsync(entity);
            if (!deleteResult.Success) return deleteResult;

            entity.AddDomainEvent(new UserDeletedEvent(command.Context,entity));
            return await Commit(_userRepository.UnitOfWork);
        }

        public async Task<DomainResponse> Handle(UpdateUserCommand command,CancellationToken cancellationToken) {
            var entities = new List<User>();
            var entity = command.Entity as User ?? await _userRepository.FindAsync(UserFilters.GetFilters(command.Query));
                
                if(entity == null) {
                    if(command.CreateIfNotExists)
                    return await Handle(new CreateUserCommand(command.Context,command.Request),cancellationToken);
                    return AddError($"Entity {nameof(User)} not found with the request.");
                }

            var entityAfter = command.Request.ProjectedAs<User>();
            
                var updateResult = await OnUpdateAsync(entity, entityAfter);
                if (!updateResult.Success) return updateResult;
                entity.AddDomainEvent(new UserUpdatedEvent(command.Context, entity));
            
            var result = await Commit(_userRepository.UnitOfWork, entity.ProjectedAs<UserDTO>());
            result.Data = entity.ProjectedAs<UserDTO>();
            return result;
        }
        }
    