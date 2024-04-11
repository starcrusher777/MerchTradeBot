using Refit;
using tradeBot.API.Models;

namespace tradeBot.API.Connector;

public interface ICommandApi
{
    [Headers("Accept: text/plain, application/json, text/json")]
    [Post("/AddOffer")]
     Task<string> OfferModel<T>([Body] T commandModel);
}