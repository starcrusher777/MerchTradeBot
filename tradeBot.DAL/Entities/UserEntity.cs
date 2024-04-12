namespace tradeBot.DAL.Entities;

public class UserEntity
{
    public long Id { get; set; }
    public long TelegramId { get; set; }
    public string Username { get; set; }
    public long password { get; set; }
    public List<OfferEntity> Offers { get; set; } = new();
    public virtual TelegramCacheEntity TelegramCache { get; set; } = new();
}