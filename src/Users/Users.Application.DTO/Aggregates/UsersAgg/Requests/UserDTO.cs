using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bmg.Desafio.Users.Application.DTO.Aggregates.UsersAgg.Requests;

using Core.Application.DTO.Aggregates.CommonAgg.Models;

public partial class UserDTO : EntityDTO
	{
	    [Required] public  string Name { get; set; }
	    public  Bmg.Desafio.Users.Enumerations.UserRole? UserRole { get; set; }
	    public  bool? NeedSendOnboardingMail { get; set; }
	    [Required] public  string Document { get; set; }
	    [Required] public  string Email { get; set; }
	    [Required] public  string PhoneNumber { get; set; }
	    [Required] public  string UserName { get; set; }
	    [Required] public  string Password { get; set; }
	    [JsonIgnore] public  string? AuthToken { get; set; }
	}
