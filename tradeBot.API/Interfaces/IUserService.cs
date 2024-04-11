using tradeBot.DAL.Entities;

namespace tradeBot.API.Interfaces;

public interface IUserService
{
    Task<UserEntity> GetUserAsync(long telegramId);
}