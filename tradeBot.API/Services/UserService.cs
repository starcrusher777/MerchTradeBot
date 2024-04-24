using System.Data.Entity;
using AutoMapper;
using tradeBot.API.Interfaces;
using tradeBot.API.Models;
using tradeBot.DAL.Database;
using tradeBot.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using tradeBot.API.Interfaces.Auth;
using tradeBot.API.Interfaces.User;

namespace tradeBot.API.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;
    private readonly ApplicationContext _database;

    public UserService(IMapper mapper, IAuthService authService, ApplicationContext database)
    {
        _mapper = mapper;
        _authService = authService;
        _database = database;
    }
    
    public async Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest model)
    {
        var user = await _database.User
            .FirstOrDefaultAsync(x => x.Username == model.Username && x.Password == model.Password);
    
        if (user == null)
        {
            return null;
        }
    
        var encodedJwt = _authService.GenerateJwtTokenSync(user);
    
        return new AuthenticateResponse(user, encodedJwt);
    }

    public Task<UserEntity> GetUserAsync(long telegramId)
    {
        throw new NotImplementedException();
    }
}