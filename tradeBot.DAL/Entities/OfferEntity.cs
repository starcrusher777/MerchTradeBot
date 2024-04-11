using System.ComponentModel.DataAnnotations;
using tradeBot.DAL.Enums;

namespace tradeBot.DAL.Entities;

public class OfferEntity
{
    [Key]
    public long Id { get; set; }
    
    [Required]
    public long UserId { get; set; }
    public string OfferType { get; set; }
    public string Name { get; set; }
    public long Price { get; set; }
    public string Description { get; set; }
    public byte[] ImageData { get; set; }
    
}