using tradeBot.DAL.Entities;

namespace tradeBot.API.Interfaces.Offer;

public interface IOfferServiceAsync
{
    Task<OfferEntity> CreateOffer(long userId, string offerType, string name, long price, string description,
        byte[] imageData);

    Task<List<OfferEntity>> GetAllOffersAsync();
    Task<List<OfferEntity>> GetOffersByUserId(long telegramId);

}