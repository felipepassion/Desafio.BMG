using Bmg.Desafio.Users.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Identity;

namespace Bmg.Desafio.Users.Api
{
    public static class IdentityApiExtensions
    {
        // Maps the new Identity minimal API endpoints under /identity
        public static void MapIdentityApiEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/identity");
            group.MapIdentityApi<ApplicationUser>();
        }
    }
}