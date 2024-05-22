using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using tradeBot.API.Interfaces.User;
using tradeBot.API.Models;
using tradeBot.DAL.Entities;

namespace tradeBot.API.Controllers;


[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;


    public UserController(IMapper mapper, IUserService userService)
    {
        _mapper = mapper;
        _userService = userService;
    }

    [HttpPost("Auth")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest model)
    {
        var response = await _userService.AuthenticateAsync(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });
        return Ok(response);
    }

    [HttpGet("GetUserById")]
    public async Task<UserModel> GetUserById(long telegramId) => _mapper.Map<UserModel>(await _userService.GetUserById(telegramId));
}