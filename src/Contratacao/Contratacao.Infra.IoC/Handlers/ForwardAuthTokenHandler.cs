using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bmg.Desafio.Contratacao.Infra.IoC.Handlers
{
    internal class ForwardAuthTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ForwardAuthTokenHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var ctx = _httpContextAccessor.HttpContext;
            if (ctx != null)
            {
                if (ctx.Request.Headers.TryGetValue("Authorization", out var authorization))
                {
                    if (!request.Headers.Contains("Authorization"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", authorization.ToString());
                    }
                }

                // Forward cookies as well, in case downstream uses shared cookie auth
                if (ctx.Request.Headers.TryGetValue("Cookie", out var cookie))
                {
                    if (!request.Headers.Contains("Cookie"))
                    {
                        request.Headers.TryAddWithoutValidation("Cookie", cookie.ToString());
                    }
                }
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
