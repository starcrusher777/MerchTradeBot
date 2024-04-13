using Refit;

namespace tradeBot.Connector.API;

public interface ITelegramApi
{
    [Get("/GetPreviousMenu")]
    Task<string> GetPreviousMenu([Query] long telegramId);
    
    [Get("/SetPreviousMenu")]
    Task SetPreviousMenu([Query] long telegramId, [Query] string menuName);
}