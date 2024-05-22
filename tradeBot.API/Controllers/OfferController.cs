using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using tradeBot.API.Interfaces.Offer;
using tradeBot.API.Interfaces.User;
using tradeBot.API.Models;
using tradeBot.DAL.Entities;

namespace tradeBot.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class OfferController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly IOfferService _offerService;

    public OfferController(IMapper mapper, IUserService userService, IOfferService offerService)
    {
        _mapper = mapper;
        _userService = userService;
        _offerService = offerService;
    }
    
    [HttpPost("CreateOffer")]
    public async Task<string> CreateOffer(long userId, string offerType, string name, long price, string description, byte[] imageData)
    {
        var offer = new OfferModel
        {
            UserId = userId,
            OfferType = offerType,
            Name = name,
            Price = price,
            Description = description,
            ImageData = imageData
        };

        return "success";
    }

    [HttpGet("GetAllOffers")]
    public async Task<List<OfferModel>> GetAllOffers()
    {
        var offers = await _offerService.GetAllOffersAsync();
        return _mapper.Map<List<OfferEntity>, List<OfferModel>>(offers);
    }
    
    [HttpGet("GetOffersByUserId")]
    public async Task<List<OfferModel>> GetOffersByUserId(long telegramId)
    {
        var userOffers = await _offerService.GetOffersByUserId(telegramId);
        return _mapper.Map<List<OfferEntity>, List<OfferModel>>(userOffers);
    }
}