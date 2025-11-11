


using MediatR;
using System.Linq.Expressions;

namespace Bmg.Desafio.Contratacao.Application.Aggregates.ContratacaoAgg.AppServices;
	using Core.Application.DTO.Http.Models.Responses;
	using CrossCuting.Infra.Utils.Extensions;
	using Application.DTO.Aggregates.ContratacaoAgg.Requests;
	using Domain.Aggregates.ContratacaoAgg.Queries.Models;
	using Domain.Aggregates.ContratacaoAgg.Repositories;
	using Domain.Aggregates.ContratacaoAgg.Filters;
	using Domain.Aggregates.ContratacaoAgg.Entities;
	using Domain.Aggregates.ContratacaoAgg.Commands;
	using Core.Application.DTO.Extensions;
	using Core.Application.Aggregates.Common;

	public partial class ContratoAppService : BaseAppService, IContratoAppService {	
		public IContratoRepository _contratoRepository;
		public ContratoAppService(IMediator mediator, Bmg.Desafio.CrossCutting.Infra.Log.Contexts.ILogRequestContext ctx, IContratoRepository contratoRepository) : base(ctx, mediator) { _contratoRepository = contratoRepository; }	
		public async Task<ContratoDTO> Get(ContratoQueryModel request) {
            return (await _contratoRepository.FindAsync(filter: ContratoFilters.GetFilters(request, isOrSpecification: request.IsOrSpecification), selector: x => x.ProjectedAs<ContratoDTO>()));
        }
		public void Dispose()
        {
			_contratoRepository = null;
        }
		public async Task<IEnumerable<T>> GetAll<T>(ContratoQueryModel request, int? page = null, int? size = null, Expression<Func<Contrato, T>> selector = null) {
			return await _contratoRepository.SelectAllAsync(
                filter: ContratoFilters.GetFilters(request, isOrSpecification: request.IsOrSpecification),
                take: size,
                skip: page * size,
				ascending: request.OrderByDesc != true,
                orderBy: request.OrderBy.GetPropertyListSelector<Contrato>(),
                selector: selector);
		}
		public async Task<T> Select<T>(ContratoQueryModel request, Expression<Func<Contrato, T>> selector = null)
        {
            return (await _contratoRepository.FindAsync(filter: ContratoFilters.GetFilters(request, isOrSpecification: true), selector: selector));
        }
        public async Task<IEnumerable<ContratoDTO>> GetAll(ContratoQueryModel request, int? page = null, int? size = null) {
            return await _contratoRepository.FindAllAsync(
                filter: ContratoFilters.GetFilters(request, isOrSpecification: true),
                take: size,
                skip: page * size,
				ascending: request.OrderByDesc != true,
                orderBy: request.OrderBy.GetPropertyListSelector<Contrato>(),
                selector: x => x.ProjectedAs<ContratoDTO>());
        }

		public Task<DomainResponse> Create(ContratoDTO request, bool updateIfExists = true, ContratoQueryModel searchQuery = null) { return _mediator.Send(new CreateContratoCommand(_logRequestContext, request)); }
		public async Task<int> CountAsync(ContratoQueryModel request) { return await _contratoRepository.CountAsync(filter: ContratoFilters.GetFilters(request, isOrSpecification: true)); }
		public Task Update(ContratoQueryModel searchQuery, ContratoDTO request, bool createIfNotExists = true) { return _mediator.Send(new UpdateContratoCommand(_logRequestContext, searchQuery, request)); }
		public Task<DomainResponse> DeleteRange(ContratoQueryModel request){ return _mediator.Send(new DeleteRangeContratoCommand(_logRequestContext, request)); }
		public Task<DomainResponse> Delete(ContratoQueryModel request){ return _mediator.Send(new DeleteContratoCommand(_logRequestContext, request)); }
	}
