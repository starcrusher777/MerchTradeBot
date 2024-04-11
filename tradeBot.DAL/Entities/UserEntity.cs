namespace tradeBot.DAL.Entities;

public class UserEntity
{
    public long Id { get; set; }
    public string Username { get; set; }
    public List<OfferEntity> Offers { get; set; } = new();
}