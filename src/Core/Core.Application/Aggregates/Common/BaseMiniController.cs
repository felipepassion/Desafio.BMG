using Microsoft.AspNetCore.Mvc;

namespace Bmg.Desafio.Core.Application.Aggregates.Common
{
    public class BaseMiniController : ControllerBase
    {
        protected readonly IServiceProvider _scope;

        public BaseMiniController(IServiceProvider scope)
        {
            _scope = scope;
        }
    }
}