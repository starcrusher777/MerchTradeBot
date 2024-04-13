using Refit;

namespace tradeBot.Connector.API;

public interface IOfferApi
{
    [Headers("Accept: text/plain, application/json, text/json")]
    [Post("/AddOffer")]
    Task<string> OfferModel<T>([Body] T offerModel);
}
