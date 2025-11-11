using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Bmg.Desafio.Proposta.Api {
    using Infra.Data.Context;
    public static partial class IoCFactory {
       
		public static void InjectDependencies(this IServiceCollection services, IConfiguration configuration) {
                    Bmg.Desafio.Proposta.Infra.IoC.IoCFactory.Current.Configure(configuration, services);
            Bmg.Desafio.Core.Infra.IoC.IoCFactory.Current.Configure(configuration, services);
            services.ConfigureAuthentication(configuration);
		}

        private static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataProtection()
                .PersistKeysToDbContext<PropostaAggContext>()
                .SetApplicationName("SharedCookieApp");

            var issuer = configuration["Jwt:Issuer"];
            var audience = configuration["Jwt:Audience"];
            var secret = configuration["Jwt:Secret"];
            if (string.IsNullOrWhiteSpace(secret))
                throw new InvalidOperationException("Jwt:Secret n?o configurado");

            var key = Encoding.UTF8.GetBytes(secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            })
            .AddCookie("Identity.Application", options =>
            {
                options.Cookie.Name = ".AspNet.SharedCookie";
            });
        }

        public static void OnAppInitialized(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var logProvider = scope.ServiceProvider.GetRequiredService<Bmg.Desafio.CrossCutting.Infra.Log.Providers.ILogProvider>();
                logProvider.Write(new Bmg.Desafio.CrossCutting.Infra.Log.Entries.LogEntry("------> APP | Proposta.Api | STARTED <------", action: "OnAppInitialized"));
            }
        }
    }
}
