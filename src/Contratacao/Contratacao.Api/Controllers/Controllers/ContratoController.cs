
using Microsoft.AspNetCore.Mvc;

namespace Bmg.Desafio.Contratacao.Api.Controllers;

using Core.Application.Aggregates.Common;
using Core.Application.Extensions;
using Core.Application.DTO.Http.Models.Responses;
using Domain.Aggregates.ContratacaoAgg.Queries.Models;
using Application.Aggregates.ContratacaoAgg.AppServices;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
public partial class ContratoController : BaseMiniController
{
    IContratoAppService _contratoAppService;
    public ContratoController(
        IServiceProvider scope,
        IContratoAppService contratoAppService)
            : base(scope)
    {
        _contratoAppService = contratoAppService;
    }
    [HttpGet("{externalId:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid externalId)
    {
        var obj = await _contratoAppService.Get(new ContratoQueryModel { ExternalIdEqual = externalId.ToString() });
        return obj == null ? NotFound() : Ok(GetHttpResponseDTO.Ok(obj));
    }
    [HttpGet("search")]
    public async Task<GetHttpResponseDTO<object>> Get([FromQuery] ContratoQueryModel request, int page = 0, int size = 5)
    {
        var obj = await _contratoAppService.GetAll(request, page, size);
        return GetHttpResponseDTO.Ok(obj);
    }
    [HttpPost("proposta/{propostaExternalId}/contratar")]
    public async Task<ObjectResult> Post(string propostaExternalId, Application.DTO.Aggregates.ContratacaoAgg.Requests.ContratoDTO request)
    {
        var loggedUserId = User.GetLoggedInUserId<int>();
        request.PropostaExternalId = propostaExternalId;
        var result = await _contratoAppService.Create(request);
        return result.Success ? Ok(GetHttpResponseDTO.Ok(result)) : StatusCode(400, GetHttpResponseDTO.BadRequest(result));
    }
    [HttpPut("{externalId:Guid}")]
    public async Task<ObjectResult> Post([FromRoute] Guid externalId, Application.DTO.Aggregates.ContratacaoAgg.Requests.ContratoDTO request)
    {
        var loggedUserId = User.GetLoggedInUserId<int>();
        request.ExternalId = externalId.ToString();
        var result = await _contratoAppService.Create(request);
        return result.Success ? Ok(GetHttpResponseDTO.Ok(result)) : StatusCode(400, GetHttpResponseDTO.BadRequest(result));
    }
    [HttpDelete("{externalId:Guid}")]
    public async Task<GetHttpResponseDTO<object>> Delete([FromRoute] Guid externalId)
    {
        var result = await _contratoAppService.Delete(new ContratoQueryModel { ExternalIdEqual = externalId.ToString() });
        return result.Success ? GetHttpResponseDTO.Ok(result) : GetHttpResponseDTO.BadRequest(result);
    }
}
