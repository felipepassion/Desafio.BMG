using AutoMapper;
namespace Bmg.Desafio.Users.Domain.Aggregates.UsersAgg.Profiles
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
