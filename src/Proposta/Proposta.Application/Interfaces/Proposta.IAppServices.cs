
using System.Linq.Expressions;

namespace Bmg.Desafio.Proposta.Application.Aggregates.PropostaAgg.AppServices;
	using Application.DTO.Aggregates.PropostaAgg.Requests;
    using Domain.Aggregates.PropostaAgg.Queries.Models;
	using Core.Application.Aggregates.Common;
	using Core.Application.DTO.Http.Models.Responses;

	public partial interface IPropostaAppService : IBaseAppService {	
		public Task<PropostaDTO> Get(PropostaQueryModel request);
		public Task<int> CountAsync(PropostaQueryModel request);
		public Task<IEnumerable<PropostaDTO>> GetAll(PropostaQueryModel request, int? page = null, int? size = null);
		public Task<T> Select<T>(PropostaQueryModel request, Expression<Func<Domain.Aggregates.PropostaAgg.Entities.Proposta, T>> selector = null);
		public Task<IEnumerable<T>> GetAll<T>(PropostaQueryModel request, int? page = null, int? size = null, Expression<Func<Domain.Aggregates.PropostaAgg.Entities.Proposta, T>> selector = null);

		public Task<DomainResponse> Create(PropostaDTO request, bool updateIfExists = true, PropostaQueryModel searchQuery = null);
		public Task<DomainResponse> Delete(PropostaQueryModel request);
		public Task<DomainResponse> DeleteRange(PropostaQueryModel request);
		public Task Update(PropostaQueryModel searchQuery, PropostaDTO request, bool createIfNotExists = true);
}
	