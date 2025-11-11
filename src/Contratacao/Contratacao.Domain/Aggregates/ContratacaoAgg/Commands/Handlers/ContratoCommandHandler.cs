
using MediatR;
using Bmg.Desafio.Core.Application.DTO.Http.Models.Responses;
using Bmg.Desafio.Core.Application.DTO.Extensions;
using Bmg.Desafio.CrossCuting.Infra.Utils.Extensions;

namespace Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Commands.Handlers;
    using Filters;
    using Events;
    using Repositories;
    using Commands;
    using Entities;
    using Queries.Models;
    using Application.DTO.Aggregates.ContratacaoAgg.Requests;

    public partial class ContratoCommandHandler : BaseContratacaoAggCommandHandler<Contrato>,
        IRequestHandler<CreateContratoCommand,DomainResponse>,
        IRequestHandler<DeleteContratoCommand,DomainResponse>,
        IRequestHandler<UpdateContratoCommand,DomainResponse>
    {
        IContratoRepository _contratoRepository;

        public ContratoCommandHandler(IServiceProvider provider,IMediator mediator,IContratoRepository contratoRepository ) : base(provider,mediator) { _contratoRepository = contratoRepository; }

        partial void OnCreate(Contrato entity);
        partial void OnUpdate(Contrato entity);

        public async Task<DomainResponse> Handle(CreateContratoCommand command,CancellationToken cancellationToken) {

            Contrato entity;
            if (command.Query != null || !string.IsNullOrWhiteSpace(command.Request.ExternalId))
            {
                var filter = ContratoFilters.GetFilters(command.Query ?? new ContratoQueryModel { ExternalIdEqual = command.Request.ExternalId });
                entity = await _contratoRepository.FindAsync(filter, includeAll: false);
                if (entity != null)
                {
                    if (command.UpdateIfExists)
                        return await Handle(new UpdateContratoCommand(
                            command.Context,
                            new Queries.Models.ContratoQueryModel { ExternalIdEqual = command.Request.ExternalId },
                            command.Request),
                        cancellationToken);
                }
            }
            entity = command.Request.ProjectedAs<Entities.Contrato>();
            entity.AddDomainEvent(new ContratoCreatedEvent(command.Context,entity));

            var creationResult = await OnCreateAsync(entity);
            if (!creationResult.Success) return creationResult;
			_contratoRepository.Add(entity);

            var result = await Commit(_contratoRepository.UnitOfWork, entity.ProjectedAs<ContratoDTO>());
            result.Data = entity.ProjectedAs<ContratoDTO>();
            return result;
        }

        public async Task<DomainResponse> Handle(DeleteContratoCommand command,CancellationToken cancellationToken) {
            var filter = ContratoFilters.GetFilters(command.Query);
			var entity = await _contratoRepository.FindAsync(filter);

            if(entity is null) {
                return AddError($"Entity {nameof(Contrato)} not found with the request.");
            }
            
            if (command.IsLogicalDeletion)
                entity.Delete();
            else
			    _contratoRepository.Delete(entity);

            var deleteResult = await OnDeleteAsync(entity);
            if (!deleteResult.Success) return deleteResult;

            entity.AddDomainEvent(new ContratoDeletedEvent(command.Context,entity));
            return await Commit(_contratoRepository.UnitOfWork);
        }

        public async Task<DomainResponse> Handle(UpdateContratoCommand command,CancellationToken cancellationToken) {
            var entities = new List<Contrato>();
            var entity = command.Entity as Contrato ?? await _contratoRepository.FindAsync(ContratoFilters.GetFilters(command.Query));
                
                if(entity == null) {
                    if(command.CreateIfNotExists)
                    return await Handle(new CreateContratoCommand(command.Context,command.Request),cancellationToken);
                    return AddError($"Entity {nameof(Contrato)} not found with the request.");
                }

            var entityAfter = command.Request.ProjectedAs<Contrato>();
            
                var updateResult = await OnUpdateAsync(entity, entityAfter);
                if (!updateResult.Success) return updateResult;
                entity.AddDomainEvent(new ContratoUpdatedEvent(command.Context, entity));
            
            var result = await Commit(_contratoRepository.UnitOfWork, entity.ProjectedAs<ContratoDTO>());
            result.Data = entity.ProjectedAs<ContratoDTO>();
            return result;
        }
        }
    