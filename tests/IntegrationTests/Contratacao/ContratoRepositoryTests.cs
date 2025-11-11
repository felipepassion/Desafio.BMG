using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Bmg.Desafio.Core.Infra.IoC;
using Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Entities;
using Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Repositories;
using Bmg.Desafio.Contratacao.Infra.Data.Context;
using ContratoIoC = Bmg.Desafio.Contratacao.Infra.IoC.IoCFactory;
using MediatR;
using IntegrationTests.TestUtils;
using System.IO;

namespace IntegrationTests.Contratacao;

public class ContratoRepositoryTests
{
    private readonly ServiceProvider _provider;

    public ContratoRepositoryTests()
    {
        var services = new ServiceCollection();
        var cfg = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();

        services.AddSingleton<IConfiguration>(cfg);
        services.AddSingleton<IMediator, NoopMediator>();

        IoCFactory.Current.Configure(cfg, services); // Core
        ContratoIoC.Current.Configure(cfg, services); // Contratacao

        _provider = services.BuildServiceProvider();
        var ctx = _provider.GetRequiredService<ContratacaoAggContext>();
        ctx.Database.EnsureCreated();
    }

    [Fact]
    public async Task AddContrato_ShouldPersist()
    {
        var ctx = _provider.GetRequiredService<ContratacaoAggContext>();
        IContratoRepository repo = _provider.GetRequiredService<IContratoRepository>();

        var contrato = new Contrato(propostaId: 1, userId: 1, numeroContrato: "C-001", inicioVigencia: DateTime.UtcNow.Date, fimVigencia: DateTime.UtcNow.Date.AddDays(1));

        repo.Add(contrato);
        await ctx.SaveChangesAsync();

        var saved = await ctx.Contrato.FirstOrDefaultAsync(p => p.Id == contrato.Id);
        saved.Should().NotBeNull();
        saved!.UserId.Should().Be(1);
        saved.PropostaId.Should().Be(1);
    }
}
