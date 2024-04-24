using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using tradeBot.API.Interfaces;
using tradeBot.API.Interfaces.Auth;
using tradeBot.DAL.Database;
using tradeBot.DAL.Entities;

namespace tradeBot.API.Services;

public class AuthService : IAuthService
{

    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysupersecret_secretkey!123"));

    public string GenerateJwtTokenSync(UserEntity user)
    {
        var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Username) };

        var jwt = new JwtSecurityToken(
            issuer: "MyAuthServer",
            audience: "MyAuthClient",
            claims: claims,
            expires: DateTime.Now.AddMinutes(1),
            signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        return encodedJwt;
    }

    public string DecodeJwtTokenSync(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(token);
        var tokenS = jsonToken as JwtSecurityToken;
        var jti = tokenS.Claims.First(claim => claim.Type == ClaimTypes.Name).Value;
        return jti;

    }
}