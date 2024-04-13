using tradeBot.DAL.Entities;

namespace tradeBot.API.Models;

public class AuthenticateResponse
{
    public string Username { get; set; }
    public bool IsBanned { get; set; }
    public string Token { get; set; }
    
    public AuthenticateResponse(UserEntity user, string token)
    {
        Username = user.Username;
        IsBanned = user.IsBanned;
        Token = token;
    }
}