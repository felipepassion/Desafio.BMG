
using MediatR;
using Bmg.Desafio.Core.Application.DTO.Http.Models.Responses;
using Bmg.Desafio.Core.Application.DTO.Extensions;
using Bmg.Desafio.CrossCuting.Infra.Utils.Extensions;

namespace Bmg.Desafio.Proposta.Domain.Aggregates.PropostaAgg.Commands.Handlers;
    using Filters;
    using Events;
    using Repositories;
    using Commands;
    using Entities;
    using Queries.Models;
    using Application.DTO.Aggregates.PropostaAgg.Requests;

    public partial class PropostaCommandHandler : BasePropostaAggCommandHandler<Proposta>,
        IRequestHandler<CreatePropostaCommand,DomainResponse>,
        IRequestHandler<DeletePropostaCommand,DomainResponse>,
        IRequestHandler<UpdatePropostaCommand,DomainResponse>
    {
        IPropostaRepository _propostaRepository;

        public PropostaCommandHandler(IServiceProvider provider,IMediator mediator,IPropostaRepository propostaRepository ) : base(provider,mediator) { _propostaRepository = propostaRepository; }

        partial void OnCreate(Proposta entity);
        partial void OnUpdate(Proposta entity);

        public async Task<DomainResponse> Handle(CreatePropostaCommand command,CancellationToken cancellationToken) {

            Proposta entity;
            if (command.Query != null || !string.IsNullOrWhiteSpace(command.Request.ExternalId))
            {
                var filter = PropostaFilters.GetFilters(command.Query ?? new PropostaQueryModel { ExternalIdEqual = command.Request.ExternalId });
                entity = await _propostaRepository.FindAsync(filter, includeAll: false);
                if (entity != null)
                {
                    if (command.UpdateIfExists)
                        return await Handle(new UpdatePropostaCommand(
                            command.Context,
                            new Queries.Models.PropostaQueryModel { ExternalIdEqual = command.Request.ExternalId },
                            command.Request),
                        cancellationToken);
                }
            }
            entity = command.Request.ProjectedAs<Entities.Proposta>();
            entity.AddDomainEvent(new PropostaCreatedEvent(command.Context,entity));

            var creationResult = await OnCreateAsync(entity);
            if (!creationResult.Success) return creationResult;
			_propostaRepository.Add(entity);

            var result = await Commit(_propostaRepository.UnitOfWork, entity.ProjectedAs<PropostaDTO>());
            result.Data = entity.ProjectedAs<PropostaDTO>();
            return result;
        }

        public async Task<DomainResponse> Handle(DeletePropostaCommand command,CancellationToken cancellationToken) {
            var filter = PropostaFilters.GetFilters(command.Query);
			var entity = await _propostaRepository.FindAsync(filter);

            if(entity is null) {
                return AddError($"Entity {nameof(Proposta)} not found with the request.");
            }
            
            if (command.IsLogicalDeletion)
                entity.Delete();
            else
			    _propostaRepository.Delete(entity);

            var deleteResult = await OnDeleteAsync(entity);
            if (!deleteResult.Success) return deleteResult;

            entity.AddDomainEvent(new PropostaDeletedEvent(command.Context,entity));
            return await Commit(_propostaRepository.UnitOfWork);
        }

        public async Task<DomainResponse> Handle(UpdatePropostaCommand command,CancellationToken cancellationToken) {
            var entities = new List<Proposta>();
            var entity = command.Entity as Proposta ?? await _propostaRepository.FindAsync(PropostaFilters.GetFilters(command.Query));
                
                if(entity == null) {
                    if(command.CreateIfNotExists)
                    return await Handle(new CreatePropostaCommand(command.Context,command.Request),cancellationToken);
                    return AddError($"Entity {nameof(Proposta)} not found with the request.");
                }

            var entityAfter = command.Request.ProjectedAs<Proposta>();
            
                var updateResult = await OnUpdateAsync(entity, entityAfter);
                if (!updateResult.Success) return updateResult;
                entity.AddDomainEvent(new PropostaUpdatedEvent(command.Context, entity));
            
            var result = await Commit(_propostaRepository.UnitOfWork, entity.ProjectedAs<PropostaDTO>());
            result.Data = entity.ProjectedAs<PropostaDTO>();
            return result;
        }
        }
    