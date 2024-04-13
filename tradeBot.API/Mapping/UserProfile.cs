using AutoMapper;
using tradeBot.API.Models;
using tradeBot.DAL.Entities;

namespace tradeBot.API.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserModel, UserEntity>().ReverseMap();
    }
}