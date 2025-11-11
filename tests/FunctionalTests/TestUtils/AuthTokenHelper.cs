using System.Net.Http.Headers;
using Bmg.Desafio.Users.Domain.Aggregates.UsersAgg.Repositories;
using Bmg.Desafio.Users.Identity;
using Bmg.Desafio.Users.Identity.Security;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionalTests.TestUtils
{
    public static class AuthTokenHelper
    {
        public static async Task<string> GetFirstUserTokenAsync()
        {
            using var usersFactory = new FunctionalTests.Users.UsersApiFactory();
            // Ensure server is created so Services is available
            using var _ = usersFactory.CreateClient();
            using var scope = usersFactory.Services.CreateScope();
            var sp = scope.ServiceProvider;

            var ctx = sp.GetRequiredService<ApplicationDbContext>();
            var ctx2 = sp.GetRequiredService<IUserRepository>();
            var tokenSvc = sp.GetRequiredService<IJwtTokenService>();

            var user = ctx.Users.OrderBy(u => u.Id).FirstOrDefault();
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = $"test_{Guid.NewGuid():N}",
                    Email = $"test_{Guid.NewGuid():N}@mail.com",
                    Name = "Test User",
                    EmailConfirmed = true,
                    PhoneNumber = "123"  
                };
                ctx.Users.Add(user);


                await ctx.SaveChangesAsync();

                ctx2.Add(new Bmg.Desafio.Users.Domain.Aggregates.UsersAgg.Entities.User
                {
                    Id = user.Id,
                    Name = user.Name,
                    Document = "000.000.000-00",
                    Email = user.Email,
                    PhoneNumber = "123",
                    UserName = user.UserName,
                });
            }

            var token = tokenSvc.GenerateToken(user);
            return token;
        }

        public static string GetFirstUserToken() => GetFirstUserTokenAsync().GetAwaiter().GetResult();

        public static async Task AttachBearerAsync(params HttpClient[] client)
        {
            var token = await GetFirstUserTokenAsync();
            foreach (var c in client)
            {
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
