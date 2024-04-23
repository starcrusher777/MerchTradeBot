using tradeBot.API.Models;
using tradeBot.DAL.Entities;

namespace tradeBot.API.Interfaces;

public interface IUserServiceAsync
{
    Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest model);
    Task<UserEntity> GetUserAsync(long telegramId);
}