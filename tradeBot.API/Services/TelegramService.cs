using tradeBot.API.Interfaces.Offer;
using tradeBot.API.Interfaces.Telegram;
using tradeBot.API.Interfaces.User;
using tradeBot.DAL.Database;

namespace tradeBot.API.Services;

public class TelegramService : ITelegramService
{
    private readonly IUserService _userService;
    private readonly IOfferService _offerService;
    private readonly ApplicationContext _database;

    public TelegramService(IUserService userService, IOfferService offerService, ApplicationContext database)
    {
        _userService = userService;
        _offerService = offerService;
        _database = database;
    }

    public async Task SetPreviousMenuAsync(long telegramId, string previousMenu)
    {
        try
        {
            var user = await _userService.GetUserAsync(telegramId);
            user.TelegramCache.PreviousMenu = previousMenu;
            _database.UpdateOrInsert(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<string> GetPreviousMenuAsync(long telegramId)
    {
        var user = await _userService.GetUserAsync(telegramId);
        return user.TelegramCache.PreviousMenu;
    }

    public Task<bool> RegisterUserAsync(string username, string password, long telegramId)
    {
        throw new NotImplementedException();
    }
}