﻿using tradeBot.DAL.Database;
using tradeBot.DAL.Entities;
using tradeBot.API.Interfaces;


namespace tradeBot.API.Services;

public class OfferService : IOfferService
{
    private readonly IOfferService _offerService;
    private readonly IUserService _userService;
    private readonly ApplicationContext _database;

    public OfferService(IOfferService offerService, IUserService userService, ApplicationContext database)
    {
        _offerService = offerService;
        _userService = userService;
        _database = database;
    }

    public async Task<OfferEntity> AddOffer(long telegramId, string offerType, string name, long price, string description,
        byte[] imageData)
    {
        var user = await _userService.GetUserAsync(telegramId);
        var offer = new OfferEntity()
        {
            UserId = telegramId,
            OfferType = offerType,
            Name = name,
            Price = price,
            Description = description,
            ImageData = imageData
        };
        
        await _database.UpdateOrInsertAsync(offer);
        return offer;
    }
}