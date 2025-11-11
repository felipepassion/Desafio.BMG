using Bmg.Desafio.Contratacao.Application.Aggregates.ContratacaoAgg.AppServices;
using Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Repositories;
using Bmg.Desafio.Contratacao.Infra.Data.Aggregates.ContratacaoAgg.Repositories;
using Bmg.Desafio.Core.Application.DTO.Seedwork;
using Bmg.Desafio.Core.Domain.Aggregates.CommonAgg.Commands;
using Bmg.Desafio.Core.Infra.IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace Bmg.Desafio.Contratacao.Infra.IoC
{
    using Core.Api.Middlewares;
    using Core.Infra.IoC.Extensions;
    using Domain.Aggregates.ContratacaoAgg.Commands.Handlers;
    using Domain.Aggregates.ContratacaoAgg.Services;
    using Infra.Data.Context;
    using Handlers; // ForwardAuthTokenHandler


    public partial class IoCFactory : IBaseIoC
    {
        string connectionString;

        partial void ConfigureFactories();
        partial void ConfigureValidators();
        partial void ConfigureAdditionalAppServices(IServiceCollection services);
        partial void ConfigureAdditionalRepositories();
        partial void PreConfigureDatabase(IServiceCollection services, IConfiguration configuration);

        #region Constructor

        private static IoCFactory _current;
        public static IoCFactory Current { get { return _current ?? (_current = new IoCFactory()); } }

        #endregion

        #region Methods

        public void Configure(IConfiguration configuration, IServiceCollection services)
        {
            ConfigureFactories();
            ConfigureMediatR(services);
            ConfigureAppServices(services);
            ConfigureRepositories(services);
            ConfigureExternalClients(services, configuration);
            ConfigureDatabase(services, configuration);
            ConfigureMappings();
            ConfigureMiddleware(services);
            ConfigureControllers(services);
        }

        void ConfigureControllers(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                //options.SerializerSettings.Converters.Add(new StringEnumConverter());
                // Use the default property (Pascal) casing
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                var settings = options.SerializerSettings;
                settings.DateFormatString = "yyyy-MM-ddTHH:mm:ss";
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                settings.MissingMemberHandling = MissingMemberHandling.Ignore;
                settings.NullValueHandling = NullValueHandling.Ignore;
                settings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                settings.DefaultValueHandling = DefaultValueHandling.Ignore;
                settings.Formatting = Formatting.Indented;
                settings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                options.AllowInputFormatterExceptionMessages = false;
                //settings.Converters.Add(new TiimeOnlyJsonConverter());
            }).AddBadRequestCustomValidator(); ;
        }

        void ConfigureMiddleware(IServiceCollection services)
        {
            services.AddScoped<ErrorHandlingMiddleware>();
        }

        void ConfigureMappings()
        {
            MapperFactory.Setup(this.GetType().Namespace.Replace("Infra.IoC", "Domain"));
        }

        void ConfigureMediatR(IServiceCollection services)
        {
            services.AddMediatR((x) => { x.RegisterServicesFromAssembly(typeof(BaseCommand).GetTypeInfo().Assembly); });
            services.AddMediatR((x) => { x.RegisterServicesFromAssembly(typeof(BaseContratacaoAggCommandHandler<>).GetTypeInfo().Assembly); });

        }

        void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
        {
            PreConfigureDatabase(services, configuration);
            if (string.IsNullOrWhiteSpace(connectionString))
                connectionString = configuration.GetConnectionString("DefaultConnection")!;
            services.AddDbContext<ContratacaoAggContext>(options =>
            options.UseNpgsql(connectionString));
        }

        void ConfigureRepositories(IServiceCollection services)
        {

            services.AddScoped<IContratoRepository, ContratoRepository>();

            ConfigureAdditionalRepositories();
        }

        void ConfigureAppServices(IServiceCollection services)
        {

            services.AddScoped<IContratoAppService, ContratoAppService>();

            ConfigureAdditionalAppServices(services);
        }

        void ConfigureExternalClients(IServiceCollection services, IConfiguration configuration)
        {
            // register delegating handler to forward current auth token and cookies
            services.AddTransient<ForwardAuthTokenHandler>();

            services.AddHttpClient("PropostaService", (sp, http) =>
            {
                var baseUrl = configuration.GetValue<string>("PropostaService:BaseUrl") ?? "http://localhost:5002";
                http.BaseAddress = new Uri(baseUrl);
            })
            .AddHttpMessageHandler<ForwardAuthTokenHandler>();

            services.AddScoped<IPropostaServiceClient, PropostaServiceClient>();
        }

        #endregion
    }
}
