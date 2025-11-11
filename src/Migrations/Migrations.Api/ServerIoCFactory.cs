using Bmg.Desafio.Core.Infra.Data.Contexts;
using Bmg.Desafio.Core.Infra.IoC;
using Bmg.Desafio.Users.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
    
namespace Bmg.Desafio.Migrations.Api {
    public static partial class IoCFactory {
        static List<Type> migrationsList = [
                typeof(Bmg.Desafio.Users.Identity.ApplicationDbContext),
                typeof(Bmg.Desafio.Users.Infra.Data.Context.UsersAggContext),
                typeof(Bmg.Desafio.Proposta.Infra.Data.Context.PropostaAggContext),
                typeof(Bmg.Desafio.Contratacao.Infra.Data.Context.ContratacaoAggContext),
];
       
		public static void InjectDependencies(this IServiceCollection services, IConfiguration configuration) {

            Bmg.Desafio.Users.Identity.Infra.IoC.IoCFactory.Current.Configure(configuration, services);
            Bmg.Desafio.Users.Infra.IoC.IoCFactory.Current.Configure(configuration, services);
            Bmg.Desafio.Proposta.Infra.IoC.IoCFactory.Current.Configure(configuration, services);
            Bmg.Desafio.Contratacao.Infra.IoC.IoCFactory.Current.Configure(configuration, services);
			
            Bmg.Desafio.Core.Infra.IoC.IoCFactory.Current.Configure(configuration, services);
		}

        public static void Migrate(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                foreach (var item in migrationsList)
                {
                    (scope.ServiceProvider.GetRequiredService(item) as DbContext)
                        .Database.Migrate();
                }
            }
        }

        public static void OnAppInitialized(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var logProvider = scope.ServiceProvider.GetRequiredService<Bmg.Desafio.CrossCutting.Infra.Log.Providers.ILogProvider>();
                logProvider.Write(new Bmg.Desafio.CrossCutting.Infra.Log.Entries.LogEntry("------> APP | Migrations.Api | STARTED <------", action: "OnAppInitialized"));
            }
        }
    }
}
