
using Microsoft.AspNetCore.Mvc;

namespace Bmg.Desafio.Users.Api.Controllers;

using Core.Application.Aggregates.Common;
using Core.Application.Extensions;
using Core.Application.DTO.Http.Models.Responses;
using Domain.Aggregates.UsersAgg.Queries.Models;
using Application.Aggregates.UsersAgg.AppServices;

	[ApiController]
    [Route("api/[controller]")]
	public partial class UserController : BaseMiniController {
		IUserAppService _userAppService;
		public UserController(
			IServiceProvider scope,
			IUserAppService userAppService)
				: base(scope)
			{ 
				_userAppService = userAppService; 
			}	
		[HttpGet("{externalId:Guid}")]
		public async Task<IActionResult> GetById([FromRoute] Guid externalId) {
		    var obj = await _userAppService.Get(new UserQueryModel{ ExternalIdEqual = externalId.ToString() });
            return obj == null? NotFound() : Ok(GetHttpResponseDTO.Ok(obj));
        }
		[HttpGet("search")]
		public async Task<GetHttpResponseDTO<object>> Get([FromQuery] UserQueryModel request, int page = 0, int size = 5) {
		    var obj = await _userAppService.GetAll(request, page, size);
            return GetHttpResponseDTO.Ok(obj);
        }
		[HttpPost]
		public async Task<ObjectResult> Post(Application.DTO.Aggregates.UsersAgg.Requests.UserDTO request) {
			var loggedUserId = User.GetLoggedInUserId<int>();
			var result = await _userAppService.Create(request);
            return result.Success ? Ok(GetHttpResponseDTO.Ok(result)) : StatusCode(400, GetHttpResponseDTO.BadRequest(result));
		}
		[HttpPut("{externalId:Guid}")]
		public async Task<ObjectResult> Post([FromRoute] Guid externalId, Application.DTO.Aggregates.UsersAgg.Requests.UserDTO request) {
			var loggedUserId = User.GetLoggedInUserId<int>();
			request.ExternalId = externalId.ToString();
			var result = await _userAppService.Create(request);
            return result.Success ? Ok(GetHttpResponseDTO.Ok(result)) : StatusCode(400, GetHttpResponseDTO.BadRequest(result));
		}
		[HttpDelete("{externalId:Guid}")]
		public async Task<GetHttpResponseDTO<object>> Delete([FromRoute] Guid externalId) {
            var result = await _userAppService.Delete(new UserQueryModel{ ExternalIdEqual = externalId.ToString() });
            return result.Success ? GetHttpResponseDTO.Ok(result) : GetHttpResponseDTO.BadRequest(result);
        }
	}
