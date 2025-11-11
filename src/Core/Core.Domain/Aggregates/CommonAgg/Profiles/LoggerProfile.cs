using AutoMapper;
using Newtonsoft.Json;
using Bmg.Desafio.CrossCutting.Infra.Log.Entries;
using Bmg.Desafio.CrossCutting.Infra.Log.SeedWork;
using Bmg.Desafio.Core.Domain.Aggregates.CommonAgg.Events;
using Bmg.Desafio.Core.Domain.Aggregates.CommonAgg.Notifications;

namespace Bmg.Desafio.Core.Domain.Aggregates.CommonAgg.Profiles
{
    public partial class LoggerProfile : Profile
    {
        public LoggerProfile()
        {
            // Base map now avoids deep JSON serialization to prevent self-referencing loops
            CreateMap<BaseNotification, LogEntry>()
                .ForMember(x => x.Title, opt => opt.MapFrom(notification => $"[{notification.Context.ShortLogId}] {notification.Title}"))
                .ForMember(x => x.Action, opt => opt.MapFrom(notification => notification.GetType().Name))
                .ForMember(x => x.Level, opt => opt.MapFrom(notification => notification.LogType))
                .ForMember(x => x.Properties, opt => opt.Ignore())
                .ForMember(x => x.LogId, opt => opt.MapFrom(notification => notification.Context.LogId != Guid.Empty ? notification.Context.LogId : LoggerFactory.ExecutionKey))
                .ForMember(x => x.Content, opt => opt.MapFrom(notification =>
                    (notification as BaseEvent) != null ? ((BaseEvent)notification).Data : null
                ))
                .PreserveReferences()
                .Include<ErrorEvent, LogEntry>();

            CreateMap<ErrorEvent, LogEntry>()
                .IncludeBase<BaseNotification, LogEntry>()
                .ForMember(x => x.Content, opt => opt.Ignore());
        }
    }
}