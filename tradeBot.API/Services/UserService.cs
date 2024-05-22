using System.Data.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using tradeBot.API.Interfaces;
using tradeBot.API.Models;
using tradeBot.DAL.Database;
using tradeBot.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using tradeBot.API.Exceptions.User;
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
    
    public async Task<UserEntity> GetUserAsync(long telegramId)
    {
        throw new NotImplementedException();
    }

    public async Task<IQueryable<UserEntity>> GetUserById(long telegramId)
    {
        IQueryable<UserEntity> user = _database.Get<UserEntity>().Where(x => x.TelegramId == telegramId);
        if (user == null)
        {
            throw new UserIdNotFoundException(telegramId);
        }
        return user;
    }
}