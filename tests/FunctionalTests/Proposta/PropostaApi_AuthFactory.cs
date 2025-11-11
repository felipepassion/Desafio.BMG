using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using FunctionalTests.TestUtils;
using System.Linq;
using Bmg.Desafio.Proposta.Infra.Data.Context;
using Bmg.Desafio.Proposta.Domain.Aggregates.UsersAgg.Entities;

namespace FunctionalTests.Proposta
{
    public class PropostaApiFactory : WebApplicationFactory<Bmg.Desafio.Proposta.Api.Program>
    {
        protected override void ConfigureWebHost(Microsoft.AspNetCore.Hosting.IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Test authentication scheme with a fixed user id claim
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = TestAuthHandler.SchemeName;
                    options.DefaultChallengeScheme = TestAuthHandler.SchemeName;
                }).AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(TestAuthHandler.SchemeName, options => { });

            });
        }
    }
}
