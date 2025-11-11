


using MediatR;
using System.Linq.Expressions;

namespace Bmg.Desafio.Proposta.Application.Aggregates.PropostaAgg.AppServices;
	using Core.Application.DTO.Http.Models.Responses;
	using CrossCuting.Infra.Utils.Extensions;
	using Application.DTO.Aggregates.PropostaAgg.Requests;
	using Domain.Aggregates.PropostaAgg.Queries.Models;
	using Domain.Aggregates.PropostaAgg.Repositories;
	using Domain.Aggregates.PropostaAgg.Filters;
	using Domain.Aggregates.PropostaAgg.Entities;
	using Domain.Aggregates.PropostaAgg.Commands;
	using Core.Application.DTO.Extensions;
	using Core.Application.Aggregates.Common;

	public partial class PropostaAppService : BaseAppService, IPropostaAppService {	
		public IPropostaRepository _propostaRepository;
		public PropostaAppService(IMediator mediator, Bmg.Desafio.CrossCutting.Infra.Log.Contexts.ILogRequestContext ctx, IPropostaRepository propostaRepository) : base(ctx, mediator) { _propostaRepository = propostaRepository; }	
		public async Task<PropostaDTO> Get(PropostaQueryModel request) {
            return (await _propostaRepository.FindAsync(filter: PropostaFilters.GetFilters(request, isOrSpecification: request.IsOrSpecification), selector: x => x.ProjectedAs<PropostaDTO>()));
        }
		public void Dispose()
        {
			_propostaRepository = null;
        }
		public async Task<IEnumerable<T>> GetAll<T>(PropostaQueryModel request, int? page = null, int? size = null, Expression<Func<Proposta, T>> selector = null) {
			return await _propostaRepository.SelectAllAsync(
                filter: PropostaFilters.GetFilters(request, isOrSpecification: request.IsOrSpecification),
                take: size,
                skip: page * size,
				ascending: request.OrderByDesc != true,
                orderBy: request.OrderBy.GetPropertyListSelector<Proposta>(),
                selector: selector);
		}
		public async Task<T> Select<T>(PropostaQueryModel request, Expression<Func<Proposta, T>> selector = null)
        {
            return (await _propostaRepository.FindAsync(filter: PropostaFilters.GetFilters(request, isOrSpecification: true), selector: selector));
        }
        public async Task<IEnumerable<PropostaDTO>> GetAll(PropostaQueryModel request, int? page = null, int? size = null) {
            return await _propostaRepository.FindAllAsync(
                filter: PropostaFilters.GetFilters(request, isOrSpecification: true),
                take: size,
                skip: page * size,
				ascending: request.OrderByDesc != true,
                orderBy: request.OrderBy.GetPropertyListSelector<Proposta>(),
                selector: x => x.ProjectedAs<PropostaDTO>());
        }

		public Task<DomainResponse> Create(PropostaDTO request, bool updateIfExists = true, PropostaQueryModel searchQuery = null) { return _mediator.Send(new CreatePropostaCommand(_logRequestContext, request)); }
		public async Task<int> CountAsync(PropostaQueryModel request) { return await _propostaRepository.CountAsync(filter: PropostaFilters.GetFilters(request, isOrSpecification: true)); }
		public Task Update(PropostaQueryModel searchQuery, PropostaDTO request, bool createIfNotExists = true) { return _mediator.Send(new UpdatePropostaCommand(_logRequestContext, searchQuery, request)); }
		public Task<DomainResponse> DeleteRange(PropostaQueryModel request){ return _mediator.Send(new DeleteRangePropostaCommand(_logRequestContext, request)); }
		public Task<DomainResponse> Delete(PropostaQueryModel request){ return _mediator.Send(new DeletePropostaCommand(_logRequestContext, request)); }
	}
