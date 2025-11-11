using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Bmg.Desafio.Users.Infra.Data.Context;
using Bmg.Desafio.Users.Infra.Data.Aggregates.UsersAgg.Repositories;
using Bmg.Desafio.Users.Domain.Aggregates.UsersAgg.Entities;
using Bmg.Desafio.Users.Domain.Aggregates.UsersAgg.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Bmg.Desafio.Core.Infra.IoC;
using UsersIoC = Bmg.Desafio.Users.Infra.IoC.IoCFactory;
using MediatR;
using IntegrationTests.TestUtils;
using System.IO;

namespace IntegrationTests.Users;

public class UserRepositoryTests
{
    private readonly ServiceProvider _provider;

    public UserRepositoryTests()
    {
        var services = new ServiceCollection();
        var cfg = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();

        services.AddSingleton<IConfiguration>(cfg);
        services.AddSingleton<IMediator, NoopMediator>();

        IoCFactory.Current.Configure(cfg, services); // Core
        UsersIoC.Current.Configure(cfg, services); // Users

        _provider = services.BuildServiceProvider();
        var ctx = _provider.GetRequiredService<UsersAggContext>();
        ctx.Database.EnsureCreated();
    }

    [Fact]
    public async Task AddUser_ShouldPersist()
    {
        var ctx = _provider.GetRequiredService<UsersAggContext>();
        IUserRepository repo = _provider.GetRequiredService<IUserRepository>();

        var user = new User
        {
            Name = "Test User",
            UserName = "test.user",
            Password = "123456"
        };

        repo.Add(user);
        await ctx.SaveChangesAsync();

        var saved = await ctx.User.FirstOrDefaultAsync(u => u.UserName == "test.user");
        saved.Should().NotBeNull();
        saved!.Name.Should().Be("Test User");
    }
}
