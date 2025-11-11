using Bmg.Desafio.Core.Infra.IoC;
using Bmg.Desafio.Proposta.Domain.Aggregates.PropostaAgg.Repositories;
using Bmg.Desafio.Proposta.Infra.Data.Context;
using FluentAssertions;
using IntegrationTests.TestUtils;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using EntProposta = Bmg.Desafio.Proposta.Domain.Aggregates.PropostaAgg.Entities.Proposta;
using PropostaIoC = Bmg.Desafio.Proposta.Infra.IoC.IoCFactory;

namespace IntegrationTests.Proposta;

public class PropostaRepositoryTests
{
    private readonly ServiceProvider _provider;

    public PropostaRepositoryTests()
    {
        var services = new ServiceCollection();

        var cfg = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();

        services.AddSingleton<IConfiguration>(cfg);
        services.AddSingleton<IMediator, NoopMediator>();

        IoCFactory.Current.Configure(cfg, services); // Core
        PropostaIoC.Current.Configure(cfg, services); // Proposta

        _provider = services.BuildServiceProvider();
        var ctx = _provider.GetRequiredService<PropostaAggContext>();
        ctx.Database.EnsureCreated();
    }

    [Fact]
    public async Task AddProposta_ShouldPersist()
    {
        var ctx = _provider.GetRequiredService<PropostaAggContext>();
        IPropostaRepository repo = _provider.GetRequiredService<IPropostaRepository>();

        var proposta = new EntProposta(userId: 1, valorCobertura: 1000);

        repo.Add(proposta);
        await ctx.SaveChangesAsync();

        var saved = await ctx.Proposta.FirstOrDefaultAsync(p => p.Id == proposta.Id);
        saved.Should().NotBeNull();
        saved!.UserId.Should().Be(1);
    }
}
