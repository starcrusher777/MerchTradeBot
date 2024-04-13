namespace tradeBot.API.Models;

public class UserViewModel
{
    public long Id { get; set; }
    public string Username { get; set; }
    public List<OfferModel> Offers { get; set; }
}