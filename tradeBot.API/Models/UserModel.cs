namespace tradeBot.API.Models;

public class UserModel
{
    public long Id { get; set; }
    public long TelegramId { get; set; }
    public string Username { get; set; }
    public long Password { get; set; }
    public bool IsBanned { get; set; }
    public List<OfferModel> Offers { get; set; }
}