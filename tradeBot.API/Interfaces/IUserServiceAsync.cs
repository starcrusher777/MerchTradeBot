using tradeBot.API.Models;

namespace tradeBot.API.Interfaces;

public interface IUserServiceAsync
{
    Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest model);
}