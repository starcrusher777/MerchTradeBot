﻿using Microsoft.EntityFrameworkCore;
using tradeBot.DAL.Database;
using tradeBot.DAL.Entities;
using tradeBot.API.Interfaces;
using tradeBot.API.Interfaces.Offer;
using tradeBot.API.Interfaces.User;


namespace tradeBot.API.Services;

public class OfferService : IOfferService
{
    private readonly IUserService _userService;
    private readonly ApplicationContext _database;

    public OfferService(IUserService userService, ApplicationContext database)
    {
        _userService = userService;
        _database = database;
    }

    public async Task<OfferEntity> CreateOffer(long telegramId, string offerType, string name, long price, string description,
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
    
    public async Task<List<OfferEntity>> GetAllOffersAsync()
    {
        return await _getAllOffers().ToListAsync();
    }

    public async Task<List<OfferEntity>> GetOffersByUserId(long telegramId)
    {
        return await GetOffersByUserId(telegramId);
    }

    private IQueryable<OfferEntity> _getAllOffers()
    {
        return _database.Get<OfferEntity>();
    }
}