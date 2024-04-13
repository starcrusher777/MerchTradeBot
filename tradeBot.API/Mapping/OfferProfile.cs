using AutoMapper;
using tradeBot.API.Models;
using tradeBot.DAL.Entities;

namespace tradeBot.API.Mapping;

public class OfferProfile : Profile
{
    public OfferProfile()
    {
        CreateMap<OfferModel, OfferEntity>().ReverseMap();
    }
}