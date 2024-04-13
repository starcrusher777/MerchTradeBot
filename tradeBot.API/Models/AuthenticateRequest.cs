using System.ComponentModel.DataAnnotations;

namespace tradeBot.API.Models;

public class AuthenticateRequest
{
    [Required]
    public string Username { get; set; }
    public string Password { get; set; }
}