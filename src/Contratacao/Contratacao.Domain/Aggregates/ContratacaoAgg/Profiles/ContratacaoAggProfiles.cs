
using AutoMapper;
namespace Bmg.Desafio.Contratacao.Domain.Aggregates.ContratacaoAgg.Profiles
{
	using Application.DTO.Aggregates.ContratacaoAgg.Requests;
	using Entities;
	public partial class ContratacaoAggProfile : Profile
	{
		public ContratacaoAggProfile()
		{
			CreateMap<ContratoDTO, Contrato>().ReverseMap();
		}
	}
}
namespace Bmg.Desafio.Contratacao.Domain.Aggregates.UsersAgg.Profiles
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
