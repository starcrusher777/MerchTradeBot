namespace tradeBot.API.Interfaces.Telegram;

public interface ITelegramServiceAsync
{
    Task<bool> RegisterUserAsync(string username, string password, long telegramId);
}