namespace tradeBot.DAL.Entities;

public class UserEntity
{
    public long Id { get; set; }
    public long TelegramId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsBanned { get; set; }
    public virtual List<OfferEntity> Offers { get; set; } = new();
    public virtual TelegramCacheEntity TelegramCache { get; set; } = new();
}