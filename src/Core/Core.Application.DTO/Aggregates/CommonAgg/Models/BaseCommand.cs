using MediatR;
using Bmg.Desafio.Core.Application.DTO.Http.Models.Responses;

namespace Bmg.Desafio.Core.Application.DTO.Aggregates.CommonAgg.Models
{
    public class BaseCommand : IRequest<DomainResponse>
    {
        public string LoggedUserId { get; set; }
    }
}
