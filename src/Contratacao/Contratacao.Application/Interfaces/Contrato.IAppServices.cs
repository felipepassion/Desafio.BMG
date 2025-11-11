
using System.Linq.Expressions;

namespace Bmg.Desafio.Contratacao.Application.Aggregates.ContratacaoAgg.AppServices;
	using Application.DTO.Aggregates.ContratacaoAgg.Requests;
    using Domain.Aggregates.ContratacaoAgg.Queries.Models;
	using Core.Application.Aggregates.Common;
	using Core.Application.DTO.Http.Models.Responses;

	public partial interface IContratoAppService : IBaseAppService {	
		public Task<ContratoDTO> Get(ContratoQueryModel request);
		public Task<int> CountAsync(ContratoQueryModel request);
		public Task<IEnumerable<ContratoDTO>> GetAll(ContratoQueryModel request, int? page = null, int? size = null);
		public Task<T> Select<T>(ContratoQueryModel request, Expression<Func<Domain.Aggregates.ContratacaoAgg.Entities.Contrato, T>> selector = null);
		public Task<IEnumerable<T>> GetAll<T>(ContratoQueryModel request, int? page = null, int? size = null, Expression<Func<Domain.Aggregates.ContratacaoAgg.Entities.Contrato, T>> selector = null);

		public Task<DomainResponse> Create(ContratoDTO request, bool updateIfExists = true, ContratoQueryModel searchQuery = null);
		public Task<DomainResponse> Delete(ContratoQueryModel request);
		public Task<DomainResponse> DeleteRange(ContratoQueryModel request);
		public Task Update(ContratoQueryModel searchQuery, ContratoDTO request, bool createIfNotExists = true);
}
	