using tradeBot.DAL.Enums;

namespace tradeBot.API.Models;

public class OfferModel
{
    public long UserId { get; set; }
    public string OfferType { get; set; }
    public string Name { get; set; }
    public long Price { get; set; }
    public string Description { get; set; }
    public byte[] ImageData { get; set; }
}