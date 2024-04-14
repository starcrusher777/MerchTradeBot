using tradeBot.DAL.Entities;

namespace tradeBot.API.Interfaces;

public interface IAuthServiceSync
{
    string GenerateJwtTokenSync(UserEntity user);
}