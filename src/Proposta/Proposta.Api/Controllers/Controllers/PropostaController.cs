
using Microsoft.AspNetCore.Mvc;

namespace Bmg.Desafio.Proposta.Api.Controllers;

using Core.Application.Aggregates.Common;
using Core.Application.Extensions;
using Core.Application.DTO.Http.Models.Responses;
using Domain.Aggregates.PropostaAgg.Queries.Models;
using Application.Aggregates.PropostaAgg.AppServices;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
public partial class PropostaController : BaseMiniController
{
    IPropostaAppService _propostaAppService;
    public PropostaController(
        IServiceProvider scope,
        IPropostaAppService propostaAppService)
            : base(scope)
    {
        _propostaAppService = propostaAppService;
    }
    [HttpGet("{externalId:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid externalId)
    {
        var obj = await _propostaAppService.Get(new PropostaQueryModel { ExternalIdEqual = externalId.ToString() });
        return obj == null ? NotFound() : Ok(GetHttpResponseDTO.Ok(obj));
    }
    [HttpGet("search")]
    public async Task<GetHttpResponseDTO<object>> Get([FromQuery] PropostaQueryModel request, int page = 0, int size = 5)
    {
        var obj = await _propostaAppService.GetAll(request, page, size);
        return GetHttpResponseDTO.Ok(obj);
    }
    [HttpPost]
    public async Task<ObjectResult> Post(Application.DTO.Aggregates.PropostaAgg.Requests.PropostaDTO request)
    {
        var loggedUserId = User.GetLoggedInUserId<int>();
        var result = await _propostaAppService.Create(request);
        return result.Success ? Ok(GetHttpResponseDTO.Ok(result)) : StatusCode(400, GetHttpResponseDTO.BadRequest(result));
    }
    [HttpPut("{externalId:Guid}")]
    public async Task<ObjectResult> Put([FromRoute] Guid externalId, Application.DTO.Aggregates.PropostaAgg.Requests.PropostaDTO request)
    {
        var loggedUserId = User.GetLoggedInUserId<int>();
        request.ExternalId = externalId.ToString();
        var result = await _propostaAppService.Create(request);
        return result.Success ? Ok(GetHttpResponseDTO.Ok(result)) : StatusCode(400, GetHttpResponseDTO.BadRequest(result));
    }
    [HttpDelete("{externalId:Guid}")]
    public async Task<GetHttpResponseDTO<object>> Delete([FromRoute] Guid externalId)
    {
        var result = await _propostaAppService.Delete(new PropostaQueryModel { ExternalIdEqual = externalId.ToString() });
        return result.Success ? GetHttpResponseDTO.Ok(result) : GetHttpResponseDTO.BadRequest(result);
    }
}
