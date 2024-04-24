using tradeBot.DAL.Entities;

namespace tradeBot.API.Interfaces.Auth;

public interface IAuthServiceSync
{
    string GenerateJwtTokenSync(UserEntity user);
}