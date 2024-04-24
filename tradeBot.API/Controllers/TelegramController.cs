using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using tradeBot.API.Interfaces.Telegram;
using tradeBot.API.Interfaces.User;

namespace tradeBot.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TelegramController : ControllerBase
{
    private readonly ITelegramService _telegramService;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    
    public TelegramController(ITelegramService telegramService, IMapper mapper, IUserService userService)
    {
        _telegramService = telegramService;
        _mapper = mapper;
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<bool> RegisterUser(string username, string password, long telegramId)
    {
        return await _telegramService.RegisterUserAsync(username, password, telegramId);
    }
}