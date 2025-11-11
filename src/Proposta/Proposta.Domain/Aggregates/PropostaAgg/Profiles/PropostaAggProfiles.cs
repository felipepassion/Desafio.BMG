
using AutoMapper;
namespace Bmg.Desafio.Proposta.Domain.Aggregates.PropostaAgg.Profiles
{
	using Application.DTO.Aggregates.PropostaAgg.Requests;
	using Entities;
	public partial class PropostaAggProfile : Profile
	{
		public PropostaAggProfile()
		{
			CreateMap<PropostaDTO, Proposta>().ReverseMap();
		}
	}
}
namespace Bmg.Desafio.Proposta.Domain.Aggregates.UsersAgg.Profiles
{
	using Application.DTO.Aggregates.UsersAgg.Requests;
	using Entities;
	public partial class UsersAggProfile : Profile
	{
		public UsersAggProfile()
		{
			CreateMap<UserDTO, User>().ReverseMap();
		}
	}
}
