using tradeBot.DAL.Entities;

namespace tradeBot.API.Interfaces.Offer;

public interface IOfferServiceAsync
{
    public Task<OfferEntity> AddOffer(long userId, string offerType, string name, long price, string description,
        byte[] imageData);
}