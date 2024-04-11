using Microsoft.AspNetCore.Mvc;
using tradeBot.API.Models;
using tradeBot.DAL.Enums;

namespace tradeBot.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class OfferController : ControllerBase
{
    [HttpPost]
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
}