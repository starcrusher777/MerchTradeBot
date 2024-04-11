namespace tradeBot.API.Interfaces;

public interface ITelegramServiceAsync
{
    Task<bool> RegisterUserAsync(string username, string password, long telegramId);
}