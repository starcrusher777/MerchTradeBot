using tradeBot.API.Interfaces;
using tradeBot.DAL.Database;
using tradeBot.DAL.Entities;

namespace tradeBot.API.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly ApplicationContext _database;

    public AuthService(IUserService userService, ApplicationContext database)
    {
        _userService = userService;
        _database = database;
    }
    public string GenerateJwtTokenSync(UserEntity user)
    {
        throw new NotImplementedException();
    }
}