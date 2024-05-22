namespace tradeBot.API.Interfaces.Telegram;

public interface ITelegramServiceAsync
{
    Task<bool> RegisterUserAsync(string username, string password, long telegramId);
    Task SetPreviousMenuAsync(long telegramId, string previousMenu);
    Task<string> GetPreviousMenuAsync(long telegramId);
}