using tradeBot.API.Interfaces.User;
using tradeBot.API.Models;
using tradeBot.DAL.Entities;

namespace tradeBot.API.Interfaces.User;

public interface IUserServiceAsync
{
    Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest model);
    Task<UserEntity> GetUserAsync(long telegramId);
}