using FluentValidation.Results;
using MediatR;
using Bmg.Desafio.Core.Application.DTO.Http.Models.Responses;
using Bmg.Desafio.Core.Domain.Aggregates.CommonAgg.Entities;
using Bmg.Desafio.Core.Domain.Aggregates.CommonAgg.Notifications;
using Bmg.Desafio.CrossCutting.Infra.Log.Contexts;
using System.Text.Json.Serialization;

namespace Bmg.Desafio.Core.Domain.Aggregates.CommonAgg.Commands
{
    public abstract class BaseCommand : BaseNotification, IRequest<DomainResponse>, IBaseRequest
    {
        protected BaseCommand(ILogRequestContext ctx) 
            : base(ctx)
        {
        }

        [JsonIgnore]
        public ValidationResult? ValidationResult { get; set; }
        public IEntity? Entity { get; set; }

        public virtual bool IsValid()
        {
            return this.ValidationResult?.Errors.Any() != true;
        }
    }
}
